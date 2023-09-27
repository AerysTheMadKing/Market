using Market.Models;

namespace Market.Pages
{
    public partial class ListWeapons
    {
        public bool ShowCreate { get; set; }
        public bool EditRecord { get; set; }

        private UserDataContext? _context;


        public Weapon? WeaponToUpdate { get; set; }

        private List<Weapon> OurWeapons;
        public async Task ShowCars()
        {
            _context ??= await UserDataContextFactory.CreateDbContextAsync();

            if (_context is not null)
            {
                OurWeapons = await _context.Weapons.ToListAsync();
            }

        }
        protected override async void OnInitialized()
        {
            await ShowCars();
        }

        public async Task ShowEditForm(Weapon OurWeapon)
        {
            _context ??= await CarDataContextFactory.CreateDbContextAsync();
            WeaponToUpdate = _context.Weapons.FirstOrDefault(x => x.Id == OurWeapon.Id);
            EditRecord = true;
        }

        public async Task UpdateCar()
        {
            EditRecord = false;
            _context ??= await CarDataContextFactory.CreateDbContextAsync();

            if (_context is not null)
            {
                if (WeaponToUpdate is not null) _context.Weapons.Update(WeaponToUpdate);
                await _context.SaveChangesAsync();
            }
        }

        //Delete
        public async Task DeleteCar(Car OurCars)
        {
            _context ??= await CarDataContextFactory.CreateDbContextAsync();

            if (_context is not null)
            {
                if (OurCars is not null) _context.Car.Remove(OurCars);
                await _context.SaveChangesAsync();
            }
            await ShowCars();

        }

    }
}
}
