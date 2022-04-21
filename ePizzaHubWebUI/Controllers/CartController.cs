using ePizzaHubEntities;
using ePizzaHubModels;
using ePizzaHubServices.Interfaces;
using ePizzaHubWebUI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ePizzaHubWebUI.Controllers
{
    public class CartController : Controller 
    {
        ICartService _cartService;
        IUserAccessor _userAccessor;
        public CartController(ICartService cartService, IUserAccessor userAccessor)
        {
            _cartService = cartService;
            _userAccessor = userAccessor;

        }
       
        Guid CartId
        { 
            get
            {
                Guid Id;
                string CId = Request.Cookies["CId"];// because cart is specific to the user 
                if(string.IsNullOrEmpty(CId))
                {
                    Id = Guid.NewGuid();
                    Response.Cookies.Append("CId", Id.ToString(),
                        new CookieOptions { Expires = DateTime.Now.AddDays(1) });
                }
                else
                {
                    Id = Guid.Parse(CId);
                }
                return Id;
            }
        }

        UserModel CurrentUser
        {
            get
            {
                return _userAccessor.GetUser();
            }
        }
        public IActionResult Index()
        {
            CartModel cart = _cartService.GetCartDetails(CartId);
            return View(cart);
        }

        [Route("Cart/AddToCart/{ItemId}/{UnitPrice}/{Quantity}")]
        public IActionResult AddToCart(int ItemId, decimal UnitPrice, int Quantity)
        {

            //Cart is specific to user , so we need CurrentUser details . but that is currently added to the BaseView page(Helpers)
            //now we need to add that to BaseController 
         int UserId =   CurrentUser != null ? CurrentUser.Id : 0;
            if(ItemId >0 && Quantity >0)
            {
                Cart cart = _cartService.AddItem(UserId, CartId, ItemId, UnitPrice, Quantity);
                var data = JsonSerializer.Serialize(cart);
                return View(data);
            }
            else
            {
                return Json("");
            }
                
        }

        [Route("Cart/UpdateQuantity/{Id}/{Quantity}")]
        public IActionResult UpdateQuantity(int id , int quantity)
        {

          int count =  _cartService.UpdateQuantity(CartId,id, quantity);            
          return Json(count);

        }

        public IActionResult DeleteItem(int id)
        {
           int count = _cartService.DeleteItem(CartId, id);
            return Json(count);
        }

        public IActionResult GetCartCount()
        {
            int count = _cartService.GetCartCount(CartId);
            return Json(count);
        }
    }
}

