/*
 * Auteur : Ania Marostica, Liliana Santos
 * Date : 22/12/2022
 * Version : 1.0
 * Projet :  Kill me if you can   
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace killMeIfYouCan
{
    //methode pour les collision
    public interface ICollidable
    {
        void OnCollide(Sprite sprite);
    }
}
