using NUnit.Framework;
using ProteinTranslation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinTranslation.UnitTests
{
    public class ProteinTanslatorTests
    {
        [TestCase("ACTATGCTCTAACAT", "Position 4 Amino Acid Sequence:L")]
        [TestCase("TGGAATTTCGTGCATAGATCGGTTAATGACATATGCGTCGAACTAGGACCAACCGTAAGGATTCCGTGACTGTTATCTGATCCTGCAGGGTAAGCCGAGCCCCGAAATAAGGCGCAGTACAACCTCCGTAATAGTTCATCCTTGCGGACACAAGGTTGTAAAATCACTACGTATCACTAGCGCGCTAGCCTTAATGGCTTT")]
        [TestCase("ACTGTGCTCCGCCATAAATTTCGAGAATATACGAGCCTTTAAATGGCCAATGGCACCTGCGGGCGGTACCAAATAAATTTAAGGGATCCAGCGGTTAGAGGTCCGACACCTATTTCTCGTAATGTCCTACTGTCCTGTTTCGTAGCTTCGAAGCACCAGAATTTGGAGAGTGCACCCGGATGGTGAATCAATTCAGACTAG", "Position 43 Amino Acid Sequence:ANGTCGRYQINLRDPAVRGPTPISRNVLLSCFVASKHQNLESAPGW")]
        [TestCase("TGGATGATGCATGACTCCAGTCGGAATCACCCAGCTTTTAGAACGGCGGGTTGAATTAAGGGGCGTACCAAATGTTCAGTAGGAAGGTAAGAGGTCCGCCCGGTGATGACATCGTAGCTGGGCTTACCTTATATATTGGAA", "Position 4 Amino Acid Sequence:MHDSSRNHPAFRTAG", "Position 106 Amino Acid Sequence:TS")]
        [TestCase("TGGCCCTATCGAGGGCGTGTAATTGTTAACCAAGGAAGTCCTATGTTTAGACGGACTCTGTTATCACAGATGTCTTGCTTGAGCTAACCGCTTATCGAAGTGATGCCATAGAAGCACGCTTCCTGTGCAATGGTCTTCACGTCGTACTGACTCAATGACACCCTAGAGCGCAAAGATGCGATAGCCCATAGGACAGGTGGC", "Position 43 Amino Acid Sequence:FRRTLLSQMSCLS", "Position 103 Amino Acid Sequence:P", "Position 130 Amino Acid Sequence:VFTSY")]
        [TestCase("TggccctatcgaGGGCGTGTAATTGTTAACCAAGGAAGTCCTATGTTTAGACGGACTCTGTTATCACAGATGTCTTGCTTGAGCTAACCGCTTATCGAAGTGATGCCATAGAAGCACGCTTCCTGTGCAATGGTCTTCACGTCGTACTGACTCAATGACACCCTAGAGCGCAAAGATGCGATAGCCCATAGGACAGGTGGC", "Position 43 Amino Acid Sequence:FRRTLLSQMSCLS", "Position 103 Amino Acid Sequence:P", "Position 130 Amino Acid Sequence:VFTSY")]
        [TestCase("TGGATGATGCATGACTCCAGTCGGAATCACCCAGCTTTTAGAACGGCGGGTTGAATTAAGGGGCGTACCAAATGTTCAGTAGGAAGGTAAGAGGTCCGCCCGGTGATGACATCGTAGCTGGGCTTACCTTATATATTGGAATACCAAGTTCTTCGATTCCCCTCTATCCAGATGAGCTGCAACGATGCCCTACTCACTGCA", "Position 4 Amino Acid Sequence:MHDSSRNHPAFRTAG", "Position 106 Amino Acid Sequence:TS", "(Partial Protein)Position 172 Amino Acid Sequence:SCNDALLTA")]
        public void TranslateDNA_ValidInput_ProducesCorrectResult(string dna, params string[] expectedProteins)
        {
            var sut = new ProteinTranslator(new CodonRepository());

            var proteins = sut.TranslateDNA(dna);

            Assert.IsTrue(Enumerable.SequenceEqual(expectedProteins, proteins));
        }

        [TestCase("Partial Codon: DNA sequence contains an incomplete codon.", "TGGATGATGCATGACTCCAGTCGGAATCACCCAGCTTTTAGAACGGCGGGTTGAATTAAGGGGCGTACCAAATGTTCAGTAGGAAGGTAAGAGGTCCGCCCGGTGATGACATCGTAGCTGGGCTTACCTTATATATTGGAATACCAAGTTCTTCGATTCCCCTCTATCCAGATGAGCTGCAACGATGCCCTACTCACTGCAG")]
        [TestCase("Partial Codon: DNA sequence contains an incomplete codon.", "TGGATGATGCATGACTCCAGTCGGAATCACCCAGCTTTTAGAACGGCGGGTTGAATTAAGGGGCGTACCAAATGTTCAGTAGGAAGGTAAGAGGTCCGCCCGGTGATGACATCGTAGCTGGGCTTACCTTATATATTGGAATACCAAGTTCTTCGATTCCCCTCTATCCAGATGAGCTGCAACGATGCCCTACTCACTGC")]
        [TestCase("Partial Codon: DNA sequence contains an incomplete codon.", "TGGATGATGCATGACTCCAGTCGGAATCACCCAGCTTTTAGAACGGCGGGTTGAATTAAGGGGCGTACCAAATGTTCAGTAGGAAGGTAAGAGGTCCGCCCGGTGATGACATCGTAGCTGGGCTTACCTTATATATTGGAATACCAAGTTCTTCGATTCCCCTCTATCCAGATGAGCTGCAACGATGCCCTACTCACTG")]
        [TestCase("Invalid Char: DNA sequence contains special characters or whitespace.", " ACTGTGCTC")]
        [TestCase("Invalid Char: DNA sequence contains special characters or whitespace.", "ACTGTGCTC ")]
        [TestCase("Invalid Char: DNA sequence contains characters or numbers that can not be translated into a codon.", "UCTGTGCTC")]
        [TestCase("Invalid Char: DNA sequence contains characters or numbers that can not be translated into a codon.", "1CTGTGCTC")]
        [TestCase("Invalid Char: DNA sequence contains characters or numbers that can not be translated into a codon.", "zCTGTGCTC")]
        [TestCase("Invalid Char: DNA sequence contains special characters or whitespace.", "%CTGTGCTC")]
        public void TranslateDNA_InvalidInput_Throws(string comment, string dna)
        {
            var sut = new ProteinTranslator(new CodonRepository());

            Assert.Throws<ArgumentException>(() => sut.TranslateDNA(dna), comment);
        }

        [TestCase("ACTATGCTCTAACAT", "ACTATGATCTAACAT", "Reference Translation: Position 4 Amino Acid Sequence:L", "Comparison Translation: Position 4 Amino Acid Sequence:I", "Hamming Distance:1", "Variant List:'7C>A' Nonsynonomous,Noncoding")]
        [TestCase("GCTATGACATAAACTAAAGCAGATATGTCCCACTTCCTAATGAATTAAGGG","ACTATGACATTAACTAAAGCCGATATGTCCCACTTCCTAAAGAATTAAGGG", "Reference Translation: Position 4 Amino Acid Sequence:T, Position 25 Amino Acid Sequence:SHFLMN", "Comparison Translation: Position 4 Amino Acid Sequence:TLTKADMSHFLKN", "Hamming Distance:4", "Variant List:'1G>A' Nonsynonomous,Noncoding, '11A>T' Nonsynonomous,Noncoding,Stop, '21A>C' Synonomous,Noncoding, '41T>A' Nonsynonomous,Start")]
        public void DetectVariant_ValidInput_ProducesCorrectResult(string dnaReference, string dnaComparison , params string[] expectedVariants)
        {
            var sut = new ProteinTranslator(new CodonRepository());

            var variant = sut.DetectVariant(dnaReference, dnaComparison);

            Assert.IsTrue(Enumerable.SequenceEqual(expectedVariants, variant));
        }

        [TestCase("ACTATGCTCTAACAT", "ACTATGCTCTAA", "Variant detection failed: Length of DNA strings do not match.")]
        public void DetectVariant_InvalidInput_Throws(string comment, string dnaReference, string dnaComparison)
        {
            var sut = new ProteinTranslator(new CodonRepository());

            Assert.Throws<ArgumentException>(() => sut.DetectVariant(dnaReference, dnaComparison), comment);
        }
    }
}
