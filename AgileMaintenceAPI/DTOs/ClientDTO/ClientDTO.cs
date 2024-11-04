﻿using AgileMaintenceAPI.DTOs.AddressesDTO;
using AgileMaintenceAPI.Models;
using System.Runtime.InteropServices;

namespace AgileMaintenceAPI.DTOs.ClientDTO
{
    public class ClientDTO
    {

        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
        public ICollection<AdressesEntity> Adresses { get; set; }
    }
}
