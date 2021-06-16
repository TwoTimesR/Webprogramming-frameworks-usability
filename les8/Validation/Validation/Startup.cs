using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Validation.Data;
using Validation.Models;

namespace Validation
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddControllersWithViews();

            services.AddDbContext<DataContext>(
                options => options.UseSqlite("Data Source=student.db"));
            Seeding();
		}

		private void Seeding()
		{
			DataContext context = new DataContext(new DbContextOptionsBuilder<DataContext>()
			.UseSqlite("Data Source=student.db")
			.Options);

			using (var db = context)
			{
				if (!db.Studenten.Any())
				{
					//insert data - Studenten
					db.Add(new Student() { StudentID = 1, Voornaam = "Murak", Achternaam = "Kaya", Woonplaats = "Istandboel", Email = "Moerak_Kaya@gmail.com", Opleiding = "Bedrijfskunde", Studiepunten = 29 });
					db.Add(new Student() { StudentID = 2, Voornaam = "Mehmet", Achternaam = "Demir", Woonplaats = "Ankara", Email = "Mehmet_Demir@gmail.com", Opleiding = "Accountancy", Studiepunten = 84 });
					db.Add(new Student() { StudentID = 3, Voornaam = "Achmed", Achternaam = "Çelik", Woonplaats = "Antalya", Email = "Achmed_Çelik@gmail.com", Opleiding = "Geneeskunde", Studiepunten = 221 });
					db.Add(new Student() { StudentID = 4, Voornaam = "Mohammed", Achternaam = "Şahin", Woonplaats = "Bursa", Email = "Mohammed_Şahin@gmail.com", Opleiding = "Docent", Studiepunten = 87 });
					db.Add(new Student() { StudentID = 5, Voornaam = "Ibine", Achternaam = "Yıldız", Woonplaats = "Kayseri", Email = "Ibine_Yıldız@gmail.com", Opleiding = "Theater", Studiepunten = 54 });
					db.Add(new Student() { StudentID = 6, Voornaam = "Yusef", Achternaam = "Yıldırım", Woonplaats = "Gaziantep", Email = "Yusef_Yıldırım@gmail.com", Opleiding = "HBO-ICT", Studiepunten = 167 });
					db.Add(new Student() { StudentID = 7, Voornaam = "Emre", Achternaam = "Öztürk", Woonplaats = "Izmir", Email = "Emre_Öztürk@gmail.com", Opleiding = "Management", Studiepunten = 125 });
					db.Add(new Student() { StudentID = 8, Voornaam = "Ibahesh", Achternaam = "Aydın", Woonplaats = "Igdir", Email = "Ibahesh_Aydın@gmail.com", Opleiding = "Data-analyst", Studiepunten = 4 });
					db.Add(new Student() { StudentID = 9, Voornaam = "Orospu", Achternaam = "Özdemir", Woonplaats = "Adana", Email = "Orospu_Özdemir@gmail.com", Opleiding = "Electrotechniek", Studiepunten = 0 });
					db.Add(new Student() { StudentID = 10, Voornaam = "Arkham", Achternaam = "Doğan", Woonplaats = "Patnos", Email = "Arkham_Doğan@gmail.com", Opleiding = "Werktuigbouwkunde", Studiepunten = 36 });

					//insert data - StudentVriend
					db.Add(new StudentVriend { StudentID = 1, VriendID = 2 });
					db.Add(new StudentVriend { StudentID = 4, VriendID = 6 });
					db.Add(new StudentVriend { StudentID = 1, VriendID = 3 });
					db.Add(new StudentVriend { StudentID = 8, VriendID = 5 });
					db.Add(new StudentVriend { StudentID = 3, VriendID = 7 });
					db.Add(new StudentVriend { StudentID = 9, VriendID = 1 });
					db.SaveChanges();
				}
			}
		}

		public void topDriePunten()
		{
			
		}
		
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
