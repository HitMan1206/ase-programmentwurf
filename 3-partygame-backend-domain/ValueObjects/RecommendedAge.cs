using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.ValueObjects
{
    public sealed class RecommendedAge
    {
        private readonly int id;
        private readonly String ageRange;
        private readonly int minimumAge;

        public RecommendedAge(int id, String ageRange, int minimumAge)
        {
            if (id < 0) throw new ArgumentException("Id must be >= 0.");
            this.id = id;
            Regex AGERANGECHECK_REGEX = new Regex("(^[0-9]\\+)|(^1[0-9]\\+)|(^2[0-1]\\+)");
            if (!AGERANGECHECK_REGEX.IsMatch(ageRange)) throw new ArgumentException("AgeRange must corresponde the Format 6+.");
            this.ageRange = ageRange;
            if (minimumAge < 0 || minimumAge > 21) throw new ArgumentException("Minimum Age has to be betweeen = and 21.");
            this.minimumAge = minimumAge;
        }

        public int getId()
        {
            return id;
        }

        public String getAgeRange()
        {
            return ageRange;
        }

        public int getMinimumAge()
        {
            return minimumAge;
        }
    }
}
