using System.Collections.Generic;

namespace ProteinTranslation.Core
{
    public interface ICodonRepository
    {
        IEnumerable<Codon> GetCodons();
    }
}
