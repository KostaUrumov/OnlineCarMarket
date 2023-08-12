﻿using OnlineCarMarket_Core.Models.Countres;

namespace OnlineCarMarket_Core.Interfaces
{
    public interface ICountry
    {
        Task AddCountryAsync(AddCountryViewModel model);
        Task <List<ShowCountryModel>> GetAllCountries();
        Task<List<EditCountryViewModel>> FindCountry(int countryId);
        Task SaveNewCountry(EditCountryViewModel model);
    }
}
