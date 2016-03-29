﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRHH.Models;

namespace RRHH.DAL
{
    interface ICountryRepository: IDisposable
    {
        void Insert(Country country);
        void Update(Country country);
        void Remove(int countryId);
        Country GetCountryById(int countryId);
        IList<Country> GetCountryList();
        void Save();
    }
}
