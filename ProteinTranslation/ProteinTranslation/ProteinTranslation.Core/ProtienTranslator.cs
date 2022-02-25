using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinTranslation.Core
{
    public class ProteinTranslator
    {
        private readonly ICodonRepository codonRepository;

        public ProteinTranslator(ICodonRepository codonRepository)
        {
            this.codonRepository = codonRepository;
        }

        /// <summary>
        /// Translates the provided dna string and returns protein strings, if any. Throws
        /// exceptions if input is invalid.
        /// </summary>
        /// <param name="dna">String of base pairs.</param>
        /// <returns>
        /// Zero or more strings, where each string represents the sequence of amino acids.
        /// </returns>
        public List<string> TranslateDNA(string dna)
        {
            // Remember, DNA code for zero or more proteins, and can contain non-coding dna before,
            // after, or between proteins. Assume that input DNA would usually be >100,000 bp long,
            // and the response would be several protiens which have >1,000 amino acids.

            // Input is not case sensitive and can only contain A,C,G,T. Additionally, the input is
            // invalid if it does not end on a complete codon (i.e. the DNA length must be some
            // multiple of 3). If the end of the DNA string is reached while a protein is being
            // coded, this is also an error.

            throw new NotImplementedException("Implement this");
        }

        public string TranslateRNA(string rna)
        {
            // Same as above, but valid nucleotides are A,C,G,U. RNA (left) base pairs can be
            // translated to DNA (right) base pairs as follows: G -> C, C -> G, A -> T, U -> A. RNA
            // may only encode for a single protien if any. If it encodes for zero protiens, return
            // an empty string.

            throw new NotImplementedException("Implement this");
        }
    }
}
