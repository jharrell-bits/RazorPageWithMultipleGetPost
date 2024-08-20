using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageWithMultipleGetPost.Pages
{
    public class IndexModel : PageModel
    {
        public List<Gadget> Gadgets = new List<Gadget>();

        public IndexModel()
        {
        }

        /// <summary>
        /// Default Get
        /// </summary>
        public void OnGet()
        {
            Gadgets = GetGadgets();
        }

        /// <summary>
        /// Get data sorted by GagdetKey
        /// </summary>
        public void OnGetSortByKey()
        {
            Gadgets = GetGadgets().OrderBy(f => f.GadgetKey).ToList();
        }

        /// <summary>
        /// Get data sorted by GadgetType
        /// </summary>
        public void OnGetSortByType()
        {
            Gadgets = GetGadgets().OrderBy(f => f.GadgetType).ToList();
        }

        /// <summary>
        /// Get data sorted by UsageInstructions
        /// </summary>
        public void OnGetSortByUsageInstructions()
        {
            Gadgets = GetGadgets().OrderBy(f => f.UsageInstructions).ToList();
        }

        /// <summary>
        /// delete the Gadget from the datastore
        /// </summary>
        /// <param name="gadgetKey"></param>
        public void OnPostDelete(string gadgetKey)
        {
            // remove a Gadget temporarily
            Gadgets = GetGadgets().Where(f => f.GadgetKey != gadgetKey).OrderBy(f => f.GadgetKey).ToList();

            System.Diagnostics.Debug.WriteLine($"Delete GadgetKey {gadgetKey}");
        }

        /// <summary>
        /// handle Detail request... either display popup or navigate to detail page
        /// </summary>
        /// <param name="gadgetKey"></param>
        public void OnPostDetails(string gadgetKey)
        {
            // since this method doesn't do anything, just reset the Gadget list
            Gadgets = GetGadgets();

            System.Diagnostics.Debug.WriteLine($"Show Details for GadgetKey {gadgetKey}");
        }

        /// <summary>
        /// Generate an in-memory list of Gadgets
        /// </summary>
        /// <returns></returns>
        private List<Gadget> GetGadgets()
        {
            return new List<Gadget>() {
                new Gadget()
                {
                    GadgetKey = "1",
                    GadgetType = "Type Z",
                    UsageInstructions = "Assemble Widgets with Gadget Z."
                },
                new Gadget()
                {
                    GadgetKey = "2",
                    GadgetType = "Type X",
                    UsageInstructions = "Use Widgeths with Gadget Z."
                },
                new Gadget()
                {
                    GadgetKey = "3",
                    GadgetType = "Type Y",
                    UsageInstructions = "Test Widgets with Gadget Y."
                }
            };
        }
    }
}
