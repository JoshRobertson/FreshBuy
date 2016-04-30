using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Assignment_2.AuthenticateService;

namespace Assignment_2.Admin
{
    public partial class BadWords : Page
    {
        private readonly Assignment2Entities _db = new Assignment2Entities();
        private AlgonquinCollegeUser _currentUser;
        private bool _isAdmin;
        protected void Page_Load(object sender, EventArgs e)
        {
            _currentUser = (AlgonquinCollegeUser)HttpContext.Current.Session["CurrentUser"];
            _isAdmin = (bool) HttpContext.Current.Session["IsAdmin"];
            if (_currentUser == null ||  !_isAdmin)
            {
                Response.Redirect("/assignment2/Default.aspx");
            }

            Title = "The Naughty List";

            if (!Page.IsPostBack)
            {
                badWordsListBox.DataSource = _db.BadWords.Select(bw => bw.Word).ToList();
                badWordsListBox.DataBind();
                badWordsListBox.Rows = badWordsListBox.Items.Count;
            }

        }

        protected void AddBadWord(object sender, EventArgs e)
        {
            var newBadWord = new BadWord
            {
                Word = addBadWordBox.Text,
            };
            _db.BadWords.Add(newBadWord);
            _db.SaveChanges();
            badWordsListBox.DataBind();
            Response.Redirect(Request.RawUrl);

        }

        protected void RemoveBadWord(object sender, EventArgs e)
        {
            if (badWordsListBox.SelectedItem != null)
            {
                var selectedWord = badWordsListBox.SelectedItem.Text;
                var removeWord = _db.BadWords.Single(bw => bw.Word == selectedWord);
                _db.BadWords.Remove(removeWord);
                _db.SaveChanges();
                badWordsListBox.DataBind();
                Response.Redirect(Request.RawUrl);
            }

        }
    }
}