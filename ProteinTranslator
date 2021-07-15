using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

            IEnumerable<Codon> codons = codonRepository.GetCodons();
            List<string> proteins = new List<string>();

            CheckValidDna(dna);

            bool codeProteinFlag = false;
            string protein = "";
            int position = 0;

            for (int i = 0; i < dna.Length; i = i+3)
            {
                Codon codon = GetCodon(dna.Substring(i, 3).ToUpper());

                if (codeProteinFlag == true)
                {
                    if (codon.CodonType == CodonType.Stop)
                    {
                        codeProteinFlag = false;
                        proteins.Add($"Position {position} Amino Acid Sequence:{protein}");
                        protein = "";
                    }

                    if (codon.CodonType == CodonType.Coding || codon.CodonType == CodonType.StartOrCoding)
                        protein += codon.AminoAcid;

                    if (i == dna.Length - 3)
                        proteins.Add($"(Partial Protein)Position {position} Amino Acid Sequence:{protein}");
                }
               
                if (codon.CodonType == CodonType.StartOrCoding && codeProteinFlag == false)
                {
                    codeProteinFlag = true;
                    position =i+1;
                    continue;
                }

            }
    
            return proteins;
        }

        private Codon GetCodon(string dnaCodon) => codonRepository.GetCodons().FirstOrDefault(sequence => sequence.CodonSequence == dnaCodon);

        private void CheckValidDna(string dna)
        {
            if (dna.Length % 3 != 0)
                throw new ArgumentException("Partial Codon: DNA sequence contains an incomplete codon.");

            if (Regex.Match(dna, @"\W+").Success)
                throw new ArgumentException("Invalid Char: DNA sequence contains special characters or whitespace.");

            if (Regex.Match(dna.ToLower(), @"(?!a|g|c|t)\w").Success)
                throw new ArgumentException("Invalid Char: DNA sequence contains characters or numbers that can not be translated into a codon.");
        }

        private int GetHammingDistance(string dnaReference, string dnaComparison)
        {
            int i = 0, count = 0;
            while (i < dnaReference.Length)
            {
                if (dnaReference[i] != dnaComparison[i])
                    count++;
                i++;
            }

            return count;
        }

        public List<string> DetectVariant(string dnaReference, string dnaComparison)
        {
            List<string> variantResults = new List<string>();

            if (dnaReference.Length != dnaComparison.Length)
                throw new ArgumentException("Variant detection failed: Length of DNA strings do not match.");

            variantResults.Add($"Reference Translation: {String.Join(", ", TranslateDNA(dnaReference))}");
            variantResults.Add($"Comparison Translation: {String.Join(", ", TranslateDNA(dnaComparison))}");
            variantResults.Add($"Hamming Distance:{GetHammingDistance(dnaReference, dnaComparison).ToString()}");
            variantResults.Add($"Variant List:{String.Join(", ", CheckForVariant(dnaReference, dnaComparison))}");

            return variantResults;
        }

        private List<string> CheckForVariant(string dnaReference, string dnaCompare)
        {

            if (string.Equals(dnaReference, dnaCompare) == true)
                return null;

            List<string> variantData = new List<string>();
            int codonLength = 3;
            bool codeProteinFlag = false;


            for (int codonStart = 0; codonStart < dnaReference.Length; codonStart = codonStart + codonLength)
            {
                string varientType = null;

                Codon referenceData = GetCodon(dnaReference.Substring(codonStart, codonLength).ToUpper());
                Codon compareData = GetCodon(dnaCompare.Substring(codonStart, codonLength).ToUpper());

                if (referenceData.CodonSequence == compareData.CodonSequence)
                    continue;

                if (referenceData.CodonType == CodonType.StartOrCoding)
                    codeProteinFlag = true;


                if (!string.Equals(referenceData.AminoAcid.ToString(), compareData.AminoAcid.ToString()))
                    varientType += "Nonsynonomous,";
                if (string.Equals(referenceData.AminoAcid.ToString(), compareData.AminoAcid.ToString()) || (referenceData.CodonType == CodonType.Stop && compareData.CodonType == CodonType.Stop))
                    varientType += "Synonomous,";
                if (!string.Equals(referenceData.CodonSequence.ToString(), compareData.CodonSequence.ToString()) && codeProteinFlag == false)
                    varientType += "Noncoding,";
                if (referenceData.CodonType == CodonType.Stop && compareData.CodonType != CodonType.Stop)
                    varientType += "Stop,";
                if (referenceData.CodonType == CodonType.StartOrCoding && compareData.CodonType != CodonType.StartOrCoding)
                    varientType += "Start,";

                List<string> segments = GetVariantSequenceToken(referenceData.CodonSequence.ToString(), compareData.CodonSequence.ToString(),codonStart);


                if (!string.IsNullOrEmpty(varientType))
                {
                    variantData.Add($"\'{segments[0]}{segments[1]}>{segments[2]}\' "+ varientType.TrimEnd(','));
                }
            }

            return variantData;
        }

        private List<string> GetVariantSequenceToken(string reference, string compare, int codonStart)
        {
            List<string> segments = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                if (reference[i] != compare[i])
                {
                    segments.Add((codonStart + 1 + i).ToString());
                    segments.Add(reference[i].ToString());
                    segments.Add(compare[i].ToString());
                }
            }

            return segments;
        }

        public string TranslateRNA(string rna)
        {
            // Same as above, but valid nucleotides are A,C,G,U. RNA (left) base pairs can be
            // translated to DNA (right) base pairs as follows: G -> C, C -> G, A -> T, U -> A. RNA
            // may only encode for a single protien if any. If it encodes for zero protiens, return
            // an empty string.

            List<string> protein = TranslateDNA(ConvertToDna(rna));

            if (protein.Count()>1)
                throw new ArgumentException("Multiple Proteins");

            if (!protein.Any())
                return string.Empty;

            return protein.FirstOrDefault();
        }

        private string ConvertToDna(string rna)
        {
            rna = rna.ToLower();
            rna = rna.Replace('g', 'C');
            rna = rna.Replace('u', 'A');
            rna = rna.Replace('c', 'G');
            rna = rna.Replace('a', 'T');
            return rna;
        }
    }
}
