using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Blog.Repository;
using Newtonsoft.Json;
using Blog.Models;
using Blog.Interfaces;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Test;


public class StudentTest : IClassFixture<WebApplicationFactory<Program>>
{
  public HttpClient client;
  public StudentTest(WebApplicationFactory<Program> factory)
  {
    client = factory.WithWebHostBuilder(builder =>
    {
      builder.ConfigureServices(service =>
      {
        var descriptor = service.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<BlogContextTest>));
        if (descriptor != null)
        {
          service.Remove(descriptor);
        }
        service.AddDbContext<BlogContextTest>(options =>
        {
          options.UseInMemoryDatabase("InMemory");
        });

        service.AddScoped<IBlogContext, BlogContextTest>();
        service.AddScoped<IStudent, StudentRepository>();
        var sp = service.BuildServiceProvider();
        var scope = sp.CreateScope();
        var appContext = scope.ServiceProvider.GetRequiredService<BlogContextTest>();


        appContext.Database.EnsureDeleted();
        appContext.Database.EnsureCreated();
        appContext.Students.AddRange(StudentsMock.GetStudents());

        appContext.SaveChanges();

      });
    }).CreateClient();
  }

  [Fact]
  public async Task TestGetAllStudents()
  {
    var res = await client.GetAsync("student");
    var jsonRes = await res.Content.ReadAsStringAsync();
    var resContent = JsonConvert.DeserializeObject<List<Student>>(jsonRes);

    res.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    resContent.Count.Should().Be(2);
  }

  [Fact]
  public async Task TestGetById()
  {
    var res = await client.GetAsync("/student/1");
    var jsonRes = await res.Content.ReadAsStringAsync();
    var resContent = JsonConvert.DeserializeObject<Student>(jsonRes);

    res.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    resContent.StudentId.Should().Be(1);
  }

  [Fact]
  public async Task TestCreate()
  {
    var newStudent = new Student { Email = "student@student.com", Name = "student", Password = "student" };
    var serializeStudent = JsonConvert.SerializeObject(newStudent);
    var content = new StringContent(serializeStudent, Encoding.UTF8, "application/json");

    var res = await client.PostAsync("student", content);

    res.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
  }

  [Fact]
  public async Task TestLogin()
  {
    var student = new StudentLogin { Email = "gmail@gmail.com", Password = "gmail" };
    var jsonStudent = JsonConvert.SerializeObject(student);
    var content = new StringContent(jsonStudent, Encoding.UTF8, "application/json");

    var res = await client.PostAsync("login", content);

    res.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
  }
  [Fact]
  public async Task TestUpdate()
  {
    // Get Token
    var student = new StudentLogin { Email = "gmail@gmail.com", Password = "gmail" };
    var jsonStudent = JsonConvert.SerializeObject(student);

    var content = new StringContent(jsonStudent, Encoding.UTF8, "application/json");
    var res = await client.PostAsync("login", content);
    var token = await res.Content.ReadAsStringAsync();

    // Configs to Update Student
    var newStudent = new Student { Email = "yahoo@yahoo.com", Password = "yahoo", Name = "yahoo" };
    var jsonNewStudent = JsonConvert.SerializeObject(newStudent);
    var newContent = new StringContent(jsonNewStudent, Encoding.UTF8, "application/json");

    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

    // Update Student
    var newRes = await client.PutAsync("student/1", newContent);
    var resJsonStudent = await newRes.Content.ReadAsStringAsync();
    var newResStudent = JsonConvert.DeserializeObject<Student>(resJsonStudent);
    
    // Validate
    newRes.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    newResStudent.Name.Should().Be("yahoo");
    newResStudent.Email.Should().Be("yahoo@yahoo.com");
    newResStudent.Password.Should().Be("yahoo");
  }
  [Fact]
  public async Task TestUserDelete()
  {
    // Get Token
    var student = new StudentLogin { Email = "outlook@outlook.com", Password = "outlook" };
    var jsonStudent = JsonConvert.SerializeObject(student);

    var content = new StringContent(jsonStudent, Encoding.UTF8, "application/json");
    var res = await client.PostAsync("login", content);
    var token = await res.Content.ReadAsStringAsync();
    
    // Configs to Delete Student and Validate
    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

    var responseDelete = await client.DeleteAsync("student/2");

    responseDelete.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);

  }
}