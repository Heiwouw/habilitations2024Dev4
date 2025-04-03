using Microsoft.VisualStudio.TestTools.UnitTesting;
using habilitations2024.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using habilitations2024.model;


namespace habilitations2024.dal.Tests
{
    [TestClass()]
    public class DeveloppeurAccessTests
    {
        [TestMethod()]
        public void GetLesDeveloppeursTest_WithProfilFiltre()
        {
            var developpeurAccess = new DeveloppeurAccess();  
            var profilsEtAttentes = new Dictionary<string, int>
    {
        { "stagiaire", 6 }, 
        { "admin", 4 },     
        { "designer", 3 }, 
        { "dev-back", 3 },  
        { "dev-front", 4 } 
    };
            foreach (var profil in profilsEtAttentes)
            {
                List<Developpeur> result = developpeurAccess.GetLesDeveloppeurs(profil.Key); 
                Assert.AreEqual(profil.Value, result.Count, $"Le nombre de développeurs pour le profil {profil.Key} ne correspond pas");
            }
        }

        [TestMethod()]
        public void GetLesDeveloppeursTest_WithoutProfilFiltre()
        {
            var expectedTotalDeveloppeurs = 20;  
            var developpeurAccess = new DeveloppeurAccess();  
            List<Developpeur> result = developpeurAccess.GetLesDeveloppeurs();
            Assert.AreEqual(expectedTotalDeveloppeurs, result.Count, "Le nombre total de développeurs ne correspond pas");
        }
    }
}