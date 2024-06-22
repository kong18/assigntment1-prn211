using FStoreBOs.Data;
using FStoreRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Assignment01Project.Pages
{
    public class IndexModel : PageModel
    {
        public string Email { get; set; }
        public string PassWord {  get; set; }
        private readonly IMemberRepo memberRepo;

        public IndexModel(IMemberRepo _memberRepo)
        {
            memberRepo = _memberRepo;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            Member member = memberRepo.GetMember(Email, PassWord);
            if(member != null)
            {
                HttpContext.Session.SetString("Email", Email);
                HttpContext.Session.SetInt32("MemberId", member.MemberId);
                Response.Redirect("Products/Create");
            }
            else
            {
                Console.WriteLine("fail");
            }
        }
    }
}
