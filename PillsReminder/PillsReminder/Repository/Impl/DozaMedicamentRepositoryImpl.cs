﻿using PillsReminder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppContext = PillsReminder.Data.AppContext;

namespace PillsReminder.Repository.Impl
{
    public class DozaMedicamentRepositoryImpl : GenericRepositoryImpl<DozaMedicament>, DozaMedicamentRepository
    {
        public DozaMedicamentRepositoryImpl(AppContext context) : base(context)
        {
        }
    }
}
