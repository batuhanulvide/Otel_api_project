using HotelApiProject.BusinessLayer.Abstract;
using HotelApiProject.BusinessLayer.Concrete;
using HotelApiProject.DataAccessLayer.Abstract;
using HotelApiProject.DataAccessLayer.Concrete;
using HotelApiProject.DataAccessLayer.EntityFramework;
using HotelApiProject.WebApi.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDAL, EFAboutDAL>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDAL, EFContactDAL>();
builder.Services.AddScoped<IRoomService, RoomManager>();
builder.Services.AddScoped<IRoomDAL, EFRoomDAL>();
builder.Services.AddScoped<IServiceService, ServiceManager>();
builder.Services.AddScoped<IServiceDAL, EFServiceDAL>();
builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDAL, EFSocialMediaDAL>();
builder.Services.AddScoped<IStaffService, StaffManager>();
builder.Services.AddScoped<IStaffDAL, EFStaffDAL>();
builder.Services.AddScoped<ISubscribeService, SubscribeManager>();
builder.Services.AddScoped<ISubscribeDAL, EFSubscribeDAL>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<ITestimonialDAL, EFTestimonialDAL>();
builder.Services.AddScoped<IReservationService, ReservationManager>();
builder.Services.AddScoped<IReservationDAL, EFReservationDAL>();
builder.Services.AddScoped<IGuestService, GuestManager>();
builder.Services.AddScoped<IGuestDAL, EFGuestDAL>();

builder.Services.AddScoped<ISendMessageService, SendMessageManager>();
builder.Services.AddScoped<ISendMessageDAL, EFSendMessageDAL>();

builder.Services.AddScoped<IMessageCategoryService, MessageCategoryManager>();
builder.Services.AddScoped<IMessageCategoryDAL, EFMessageCategoryDAL>();

builder.Services.AddScoped<IWorkLocationService, WorkLocationManager>();
builder.Services.AddScoped<IWorkLocationDAL, EFWorkLocationDAL>();

builder.Services.AddScoped<IReservationStatusService, ReservationStatusManager>();
builder.Services.AddScoped<IReservationStatusDAL, EFReservationStatusDAL>();

builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<ICommentDAL, EFCommentDAL>();

builder.Services.AddAutoMapper(typeof(Program)); //Automapper


//Ýliþkili tablolarý consume ederken ReferanceHandler eklenmek zorunda *-*
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});

//API' a eriþim izni veriyoruz.
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("HotelApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("HotelApiCors"); //Yukarýda tanýmlanan Corsu buraya ekliyoruz.
app.UseAuthorization();

app.MapControllers();

app.Run();
