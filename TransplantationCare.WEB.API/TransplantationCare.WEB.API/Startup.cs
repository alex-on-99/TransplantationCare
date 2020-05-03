using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TransplantationCare.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using TransplantationCare.Core.Interfaces.Repositories;
using TransplantationCare.DataAccess.Repositories;
using TransplantationCare.Core.Interfaces.Validation;
using TransplantationCare.BusinessLogic.Validation;
using TransplantationCare.Core.Interfaces.Services;
using TransplantationCare.BusinessLogic.Services;

namespace TransplantationCare.WEB.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TransplantationCareContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("TransplantationCareConnection")));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/account/login");
                   options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/account/login");
               });

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IContractRepository, ContractRepository>();
            services.AddTransient<IChatRepository, ChatRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IProcessRepository, ProcessRepository>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<IUserContractRepository, UserContractRepository>();

            services.AddTransient<IRegisterValidation, RegisterValidation>();
            services.AddTransient<ILoginValidation, LoginValidation>();
            services.AddTransient<IRegisterCompanyValidation, RegisterCompanyValidation>();
            services.AddTransient<IContractCreationValidation, ContractCreationValidation>();
            services.AddTransient<ICreationUserContractValidation, CreationUserContractValidation>();

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IEmployeeAccountService, EmployeeAccountService>();
            services.AddTransient<IContractService, ContractService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IProcessService, ProcessService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
