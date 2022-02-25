using System;

namespace ProteinTranslation.Core
{
    public readonly struct Codon
    {
        public Codon(string codonSequence, char? aminoAcid, CodonType codonType)
        {
            CodonSequence = codonSequence ?? throw new ArgumentNullException(nameof(codonSequence));
            AminoAcid = aminoAcid;
            CodonType = codonType;
        }

        public string CodonSequence { get; }

        public char? AminoAcid { get; }

        public CodonType CodonType { get; }
    }
}
