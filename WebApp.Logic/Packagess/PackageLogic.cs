﻿using FluentValidation;
using System;
using System.Linq;
using WebApp.Logic.Interfaces;
using WebApp.Logic.Repositories;
using WebApp.Models;

namespace WebApp.Logic.Events
{
    public class PackageLogic : IPackageLogic
    {
        protected IPackageRepository Repository { get; set; }

        protected IValidator<Package> Validator { get; set; }

        public PackageLogic(IPackageRepository repository, IValidator<Package> validator)
        {
            Repository = repository;
            Validator = validator;
        }

        public Result<Package> Add(Package package)
        {
            if(package == null)
            {
                throw new ArgumentNullException("produkt");
            }

            var validationResult = Validator.Validate(package);

            if (validationResult.IsValid == false)
            {
                return Result.Error<Package>(validationResult.Errors);
            }

            Repository.Add(package);
            Repository.SaveChanges();

            return Result.Ok(package);
        }

        public Result<IQueryable<Package>> GetAllActive()
        {
            return Result.Ok(Repository.GetAllActive());
        }

        public Result<Package> GetById(int id)
        {
            var package = Repository.GetById(id);

            if(package == null)
            {
                return Result.Error<Package>("Brak zdefiniowanego pakietu");
            }

            return Result.Ok(package);
        }
    }
}
