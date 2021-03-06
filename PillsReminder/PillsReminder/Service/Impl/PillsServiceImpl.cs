﻿using Microsoft.Extensions.Options;
using PillsReminder.Entities;
using PillsReminder.Helpers;
using PillsReminder.Models;
using PillsReminder.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PillsReminder.Service.Impl
{
    public class PillsServiceImpl : PillsService
    {
        private readonly DozaMedicamentRepository dozaMedicamentRepository;
        private readonly MedicamentRepository medicamentRepository;
        private readonly UserRepository userRepository;
#pragma warning disable IDE0052 // Remove unread private members
        private readonly AppSettings appSettings;
#pragma warning restore IDE0052 // Remove unread private members

        CultureInfo provider = CultureInfo.InvariantCulture;

        public PillsServiceImpl(DozaMedicamentRepository dozaMedicamentRepository, MedicamentRepository medicamentRepository, UserRepository userRepository, IOptions<AppSettings> options)
        {
            this.dozaMedicamentRepository = dozaMedicamentRepository;
            this.medicamentRepository = medicamentRepository;
            this.userRepository = userRepository;
            this.appSettings = options.Value;
        }

        public bool CreateDoza(DozaMedicamentRequest request, int id)
        {
            for(int i = 0; i<=request.NumarZile-1; i++)
            {
                DozaMedicament dozaMedicament = new DozaMedicament();
                dozaMedicament.Luata = false;
                dozaMedicament.Cantitate_pastila = request.Cantitate_pastila;
                dozaMedicament.Ora = DateTime.ParseExact(request.Ora, "HH:mm", provider);
                dozaMedicament.Data = DateTime.ParseExact(request.DataInceput, "dd.MM.yyyy", provider).AddDays(i);
                
                User user = userRepository.FindById(id);
                dozaMedicament.User = user;

                Medicament medicament = medicamentRepository.FindById(request.IdPastila);
                dozaMedicament.Medicament = medicament;
                dozaMedicament.IdMedicament = request.IdPastila;

                dozaMedicamentRepository.Create(dozaMedicament);
            }
            return dozaMedicamentRepository.SaveChanges();
        }

        public bool DeleteDoza(int IdDoza)
        {
            DozaMedicament doza = dozaMedicamentRepository.FindById(IdDoza);
            dozaMedicamentRepository.Delete(doza);
            return dozaMedicamentRepository.SaveChanges();
        }

        public List<ListaDozeResponse> GetDoze(int Id)
        {
            List<DozaMedicament> doze = dozaMedicamentRepository.GetAll();
            List<ListaDozeResponse> dozeUtilizator = new List<ListaDozeResponse>();
            if (doze.Count > 0)
            {
                for (int i = 0; i < doze.Count; i++)
                {
                    if (doze[i].User != null)
                    {
                        if (doze[i].User.Id == Id)
                        {
                            doze[i].Medicament = medicamentRepository.FindById(doze[i].IdMedicament);

                            ListaDozeResponse listaDozeElement = new ListaDozeResponse();
                            listaDozeElement.IdMedicament = doze[i].Medicament.Id;
                            listaDozeElement.DenumireMedicament = doze[i].Medicament.Denumire;
                            listaDozeElement.IdUser = doze[i].User.Id;
                            listaDozeElement.Luata = doze[i].Luata;
                            listaDozeElement.Ora = doze[i].Ora;
                            listaDozeElement.Cantitate_pastila = doze[i].Cantitate_pastila;
                            listaDozeElement.Data = doze[i].Data;
                            listaDozeElement.Id = doze[i].Id;
                            dozeUtilizator.Add(listaDozeElement);
                        }
                    }
                }
                return dozeUtilizator;
            }
            return null;
        }

        public List<Medicament> GetPastile()
        {
            return medicamentRepository.GetAll();
        }

        public bool UpdateDoza(int IdDoza, bool Luata)
        {
            DozaMedicament doza = dozaMedicamentRepository.FindById(IdDoza);
            doza.Luata = Luata;
            dozaMedicamentRepository.Update(doza);
            return dozaMedicamentRepository.SaveChanges();
        }
    }
}
