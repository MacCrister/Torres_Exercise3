using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torres_Exercise3.Models;

namespace Torres_Exercise3.Pages
{
    public class EditModel : PageModel
    {
        public EditModel(TorresCafeDBContext editcontext)
        {
            _torrescafedbcontext = editcontext;
        }

        private readonly TorresCafeDBContext _torrescafedbcontext;

        [BindProperty]
        public Client Client { get; set; }
        public void OnGet(int id)
        {
            Client = _torrescafedbcontext.Clients.FirstOrDefault(clients => clients.ClientId == id);
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //var clnt = _torrescafedbcontext.Clients.FirstOrDefault(client => client.ClientId == Client.ClientId);
            Client clnt = new Client();
            clnt = _torrescafedbcontext.Clients.FirstOrDefault(client => client.ClientId == Client.ClientId);
            if (clnt != null)
            {
                clnt.ClientName = Client.ClientName;
                clnt.ClientAge = Client.ClientAge;
                clnt.ClientContactNo = Client.ClientContactNo;
                clnt.ClientEmailAdd = Client.ClientEmailAdd;
                clnt.ClientSubscription = Client.ClientSubscription;
                clnt.ClientAddress = Client.ClientAddress;

                _torrescafedbcontext.Update(clnt);
                _torrescafedbcontext.SaveChanges();
            }
            return Redirect("Client");
            
        }
    }
}
