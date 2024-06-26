﻿using Fittness.Data.Models;
using Fittness.Repository.IRepo;
using Fittness.Repository.Repo;

namespace Fittness.UnitOfWork;
public class UOW : IUOW
{
    public UOW(ICardRepository card, IPalateIngredientRepository ingredient, IUserRepository user)
    {

        Card = card;
        PalateIngredient = ingredient;
        User = user;
    }
    public IUserRepository User { get; set; }
    public ICardRepository Card { get; set; }
    public IPalateIngredientRepository PalateIngredient { get ; set; }
   
    public IPalate1Repository Palate1 { get; set; }

}

