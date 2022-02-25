using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinTranslation.Core
{
    public class CodonRepository : ICodonRepository
    {
        /// <summary>
        /// Returns all 64 possible codons.
        /// </summary>
        public IEnumerable<Codon> GetCodons()
        {
            return new List<Codon>()
            {
                new Codon("TTT",'F',CodonType.Coding),
                new Codon("TTC",'F',CodonType.Coding),
                new Codon("TTA",'L',CodonType.Coding),
                new Codon("TTG",'L',CodonType.Coding),
                new Codon("CTT",'L',CodonType.Coding),
                new Codon("CTC",'L',CodonType.Coding),
                new Codon("CTA",'L',CodonType.Coding),
                new Codon("CTG",'L',CodonType.Coding),
                new Codon("ATT",'I',CodonType.Coding),
                new Codon("ATC",'I',CodonType.Coding),
                new Codon("ATA",'I',CodonType.Coding),
                new Codon("ATG",'M',CodonType.StartOrCoding),
                new Codon("GTT",'V',CodonType.Coding),
                new Codon("GTC",'V',CodonType.Coding),
                new Codon("GTA",'V',CodonType.Coding),
                new Codon("GTG",'V',CodonType.Coding),
                new Codon("TCT",'S',CodonType.Coding),
                new Codon("TCC",'S',CodonType.Coding),
                new Codon("TCA",'S',CodonType.Coding),
                new Codon("TCG",'S',CodonType.Coding),
                new Codon("CCT",'P',CodonType.Coding),
                new Codon("CCC",'P',CodonType.Coding),
                new Codon("CCA",'P',CodonType.Coding),
                new Codon("CCG",'P',CodonType.Coding),
                new Codon("ACT",'T',CodonType.Coding),
                new Codon("ACC",'T',CodonType.Coding),
                new Codon("ACA",'T',CodonType.Coding),
                new Codon("ACG",'T',CodonType.Coding),
                new Codon("GCT",'A',CodonType.Coding),
                new Codon("GCC",'A',CodonType.Coding),
                new Codon("GCA",'A',CodonType.Coding),
                new Codon("GCG",'A',CodonType.Coding),
                new Codon("TAT",'Y',CodonType.Coding),
                new Codon("TAC",'Y',CodonType.Coding),
                new Codon("TAA",null,CodonType.Stop),
                new Codon("TAG",null,CodonType.Stop),
                new Codon("CAT",'H',CodonType.Coding),
                new Codon("CAC",'H',CodonType.Coding),
                new Codon("CAA",'Q',CodonType.Coding),
                new Codon("CAG",'Q',CodonType.Coding),
                new Codon("AAT",'N',CodonType.Coding),
                new Codon("AAC",'N',CodonType.Coding),
                new Codon("AAA",'K',CodonType.Coding),
                new Codon("AAG",'K',CodonType.Coding),
                new Codon("GAT",'D',CodonType.Coding),
                new Codon("GAC",'D',CodonType.Coding),
                new Codon("GAA",'E',CodonType.Coding),
                new Codon("GAG",'E',CodonType.Coding),
                new Codon("TGT",'C',CodonType.Coding),
                new Codon("TGC",'C',CodonType.Coding),
                new Codon("TGA",null,CodonType.Stop),
                new Codon("TGG",'W',CodonType.Coding),
                new Codon("CGT",'R',CodonType.Coding),
                new Codon("CGC",'R',CodonType.Coding),
                new Codon("CGA",'R',CodonType.Coding),
                new Codon("CGG",'R',CodonType.Coding),
                new Codon("AGT",'S',CodonType.Coding),
                new Codon("AGC",'S',CodonType.Coding),
                new Codon("AGA",'R',CodonType.Coding),
                new Codon("AGG",'R',CodonType.Coding),
                new Codon("GGT",'G',CodonType.Coding),
                new Codon("GGC",'G',CodonType.Coding),
                new Codon("GGA",'G',CodonType.Coding),
                new Codon("GGG",'G',CodonType.Coding),
            };
        }
    }
}
