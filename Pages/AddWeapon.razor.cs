using Market.Models;

namespace Market.Pages
{
    public partial class AddWeapon
    {
        public bool ShowCreate { get; set; }
        protected override async Task OnInitializedAsync()
        {
            ShowCreate = false;
        }
        private UserDataContext? _context;

        public Weapon? NewWeapon { get; set; }

        public void ShowCreateForm()
        {
            NewWeapon = new Weapon();
            ShowCreate = true;
        }
        public async Task CreateNewCar()
        {
            _context ??= await UserDataContextFactory.CreateDbContextAsync();
            if (NewWeapon is not null)
            {

                Console.WriteLine($"{_context?.Weapons.Add(NewWeapon)}, esskeetit");
                _context?.SaveChangesAsync();

            }
            ShowCreate = false;

        }

    }
}
