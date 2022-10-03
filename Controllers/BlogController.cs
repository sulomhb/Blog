using Microsoft.AspNetCore.Mvc;
using assignment_4.Data;
using assignment_4.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace assignment_4.Controllers;

public class BlogController : Controller
{
    private readonly ApplicationDbContext _database;
    private readonly UserManager<ApplicationUser> _userManager;

    public BlogController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
    {
        this._userManager = userManager;
        this._database= db;
    }

    public IActionResult Index() {
        var blogposts = _database.BlogPosts.ToList();
        blogposts.Reverse();
        return View(blogposts);
    }

    public IActionResult Add() {
        // Get current application user
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (currentUserId == null) return Redirect("/Blog");
        var currentUser = _userManager.Users.First(user => user.Id == currentUserId);
        if (currentUser == null) return Redirect("/Blog");

        return View();
    }

    public IActionResult Insert(string title, string summary, string content) {
        // Get current application user
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (currentUserId == null) return Redirect("/Blog");
        var currentUser = _userManager.Users.First(user => user.Id == currentUserId);
        if (currentUser == null) return Redirect("/Blog");

        _database.BlogPosts.Add(new BlogPost{Title=title, Summary=summary, Content=content, Nickname=currentUser.Nickname, Now=DateTime.Now});
        _database.SaveChanges();
        return Redirect("/Blog");
    }

    public IActionResult Edit(int id) {
        // Get current application user
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (currentUserId == null) return Redirect("/Blog");
        var currentUser = _userManager.Users.First(user => user.Id == currentUserId);
        if (currentUser == null) return Redirect("/Blog");
        var blogpost = _database.BlogPosts.First(blogpost => blogpost.ID == id);
        if (blogpost.Nickname != currentUser.Nickname) return Redirect("/Blog");

        ViewBag.ID = id;
        return View(blogpost);
    }

    public IActionResult Update(int id, string title, string summary, string content) {
        // Get current application user
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (currentUserId == null) return Redirect("/Blog");
        var currentUser = _userManager.Users.First(user => user.Id == currentUserId);
        if (currentUser == null) return Redirect("/Blog");
        var blogpost = _database.BlogPosts.First(blogpost => blogpost.ID == id);
        if (blogpost.Nickname != currentUser.Nickname) return Redirect("/Blog");
    
        blogpost.Title = title;
        blogpost.Summary = summary;
        blogpost.Content = content;
        _database.SaveChanges();
        return Redirect("/Blog");
    }
}
