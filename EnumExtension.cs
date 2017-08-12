using Cfcal.Generique.Metier.Attributes;
using System;
using System.Linq;

namespace Cfcal.Generique.Metier.Extensions
{
    public static class EnumExtension
    {

        /// <history>CFCAL/KBL, 11/08/2017 Création</history>
        /// <summary>
        /// Permet de retourner l'attribut personnalisé passé en paramètre d'une énumération.
        /// </summary>
        /// <typeparam name="TAttribute">L'attribut personnalisé recherché</typeparam>
        /// <param name="peEnum">L'énumération</param>
        /// <returns>L'attribut TAttribute ou null si non trouvé</returns>
        /// <exception cref="ArgumentNullException">Si peEnum est null</exception>
        public static TAttribute RetournerAttribut<TAttribute>(this Enum peEnum) where TAttribute : Attribute
        {
            //>Declaration
            Type loTypeEnum = default(Type);
            string lstrNomEnum = null;

            //>Vérification
            if (peEnum == null)
                throw new ArgumentNullException();

            //>Traitement
            loTypeEnum = peEnum.GetType();
            lstrNomEnum = Enum.GetName(loTypeEnum, peEnum);

            //>Retour
            return loTypeEnum.GetField(lstrNomEnum).GetCustomAttributes(true).OfType<TAttribute>().SingleOrDefault();
        }

        /// <history>CFCAL/KBL, 11/08/2017 Création</history>
        /// <summary>
        /// Permet de retourner le libelle d'une enum
        /// </summary>
        /// <param name="peEnum">La valeur de l'enum</param>
        /// <returns>Le libelle de la valeur ou une chaine vide si non existant</returns>
        /// <exception cref="NotSupportedException">Levée si <param name="peEnum"> ne contient pas d'attribut <see cref="EnumLibelleAttribute"/></exception>
        public static string RetournerLibelle(this Enum peEnum)
        {
            //>Traitement
            var loEnumLibelleAttribute = peEnum.RetournerAttribut<EnumLibelleAttribute>();

            if (loEnumLibelleAttribute == null)
                throw new NotSupportedException();

            //>Retour
            return peEnum.RetournerAttribut<EnumLibelleAttribute>().Libelle;
        }
    }
}
