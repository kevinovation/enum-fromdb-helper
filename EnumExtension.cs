using Cfcal.Generique.Metier.Attributes;
using System;
using System.Linq;

namespace Extensions
{
    public static class EnumExtension
    {

        /// <summary>
        /// Return the passed custom attribute.
        /// </summary>
        /// <typeparam name="TAttribute">The wanted custom attribute</typeparam>
        /// <param name="peEnum">The enum</param>
        /// <returns> TAttribute or null if not found</returns>
        /// <exception cref="ArgumentNullException">If peEnum is null</exception>
        public static TAttribute ReturnAttribute<TAttribute>(this Enum peEnum) where TAttribute : Attribute
        {
            //>Declaration
            Type loEnumType = default(Type);
            string lstrEnumName = null;

            //>Vérification
            if (peEnum == null)
                throw new ArgumentNullException();

            //>Traitement
            loEnumType = peEnum.GetType();
            lstrEnumName = Enum.GetName(loEnumType, peEnum);

            //>Retour
            return loEnumType.GetField(lstrEnumName).GetCustomAttributes(true).OfType<TAttribute>().SingleOrDefault();
        }

        /// <summary>
        /// Return the enum's libelle
        /// </summary>
        /// <param name="peEnum">The enum</param>
        /// <returns>The enum's libelle</returns>
        /// <exception cref="NotSupportedException">Throw if <param name="peEnum"> doesn't have attribute <see cref="EnumLibelleAttribute"/></exception>
        public static string ReturnLibelle(this Enum peEnum)
        {
            //>Traitement
            var loEnumLibelleAttribute = peEnum.ReturnAttribute<EnumLibelleAttribute>();

            if (loEnumLibelleAttribute == null)
                throw new NotSupportedException();

            //>Retour
            return loEnumLibelleAttribute.Libelle;
        }
    }
}
