using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CargoApp.Models
{
    public class CargoInitializer:DropCreateDatabaseIfModelChanges<CargoContext> 
    {
        protected override void Seed(CargoContext context)
        {   
            //Test verileri
            //Veri tabanı ilk oluştuğunda girilcek olan veriler.

            List<Users> users = new List<Users>()
            {
                new Users() {FirstName = "Furkan",LastName = "Cabbar",Password = "123",EmailAddress = "ffcabbar@gmail.com",Phone = "0534 821 5356"},
                new Users() {FirstName = "İsmail",LastName = "Doğan",Password = "123",EmailAddress = "isodgn@gmail.com",Phone = "0542 676 2355"},
                new Users() {FirstName = "Fatih",LastName = "İpek",Password = "123",EmailAddress = "fipek@gmail.com",Phone = "0567 678 4564"}
            };
            foreach (var item in users)
            {
                context.User.Add(item);
            }
            context.SaveChanges();


            List<Categories> categories = new List<Categories>()
            {
                new Categories() {CategoryName = "Small"},
                new Categories() {CategoryName = "Medium"},
                new Categories() {CategoryName = "Large"}
            };
            foreach (var item in categories)
            {
                context.Categories.Add(item);
            }
            context.SaveChanges();



            List<CargoStatus> cargoStatuses = new List<CargoStatus>()
            {
                new CargoStatus() {StatusName = "İşleme alındı... "},
                new CargoStatus() {StatusName = "Ürün hazırlanıyor... "},
                new CargoStatus() {StatusName = "Ürün kargoya verildi... "},
                new CargoStatus() {StatusName = "Ürün dağıtıma çıktı... "},
                new CargoStatus() {StatusName = "Ürün teslim edildi "}
            };
            foreach (var item in cargoStatuses)
            {
                context.CargoStatus.Add(item);
            }
            context.SaveChanges();


            List<Cargo> cargos = new List<Cargo>()
            {
                new Cargo() {CargoNumber = "2145 6523 89",CategoryId = 2,CargoStatusId = 1},
                new Cargo() {CargoNumber = "4521 9856 25",CategoryId = 3,CargoStatusId = 4}
            };
            foreach (var item in cargos)
            {
                context.Cargo.Add(item);
            }
            context.SaveChanges();


            List<UserAddresses> userAddresses = new List<UserAddresses>()
            {
                new UserAddresses() {AddressName = "Home",City = "İstanbul",Address = "Seyyid ömer mah. hekimoğlu alipaş cad. no/118",UserId = 1},
                new UserAddresses() {AddressName = "Home",City = "İstanbul",Address = "Beyoğlu mah. kiraz cad. no/3",UserId = 2}
            };
            foreach (var item in userAddresses)
            {
                context.UserAddresses.Add(item);
            }
            context.SaveChanges();



            List<CargoProcess> cargoProcesses = new List<CargoProcess>()
            {
                new CargoProcess() {Explanation = "Ürün A şubesinden çıktı B şubesini gidiyor",CargoId = 1,CargoStatusId = 2}
            };
            context.CargoProcess.AddRange(cargoProcesses);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}