using System;
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.IO.Util;
using iText.Kernel;
using iText.Kernel.Pdf;
using iText.Test;

namespace iText.Kernel.Font {
    public class PdfFontFactoryTest : ExtendedITextTest {
        public static readonly String sourceFolder = iText.Test.TestUtil.GetParentProjectDirectory(NUnit.Framework.TestContext
            .CurrentContext.TestDirectory) + "/resources/itext/kernel/font/";

        [NUnit.Framework.Test]
        public virtual void StandardFontForceEmbeddedTest() {
            Type1Font fontProgram = (Type1Font)FontProgramFactory.CreateFont(StandardFonts.HELVETICA);
            NUnit.Framework.Assert.That(() =>  {
                PdfFontFactory.CreateFont(fontProgram, PdfEncodings.UTF8, PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);
            }
            , NUnit.Framework.Throws.InstanceOf<PdfException>().With.Message.EqualTo(PdfException.CannotEmbedStandardFont))
;
        }

        [NUnit.Framework.Test]
        public virtual void StandardFontPreferEmbeddedTest() {
            Type1Font fontProgram = (Type1Font)FontProgramFactory.CreateFont(StandardFonts.HELVETICA);
            PdfType1Font font = (PdfType1Font)PdfFontFactory.CreateFont(fontProgram, PdfEncodings.UTF8, PdfFontFactory.EmbeddingStrategy
                .PREFER_EMBEDDED);
            NUnit.Framework.Assert.IsNotNull(font);
            NUnit.Framework.Assert.IsFalse(font.IsEmbedded());
        }

        [NUnit.Framework.Test]
        public virtual void StandardFontPreferNotEmbeddedTest() {
            Type1Font fontProgram = (Type1Font)FontProgramFactory.CreateFont(StandardFonts.HELVETICA);
            PdfType1Font font = (PdfType1Font)PdfFontFactory.CreateFont(fontProgram, PdfEncodings.UTF8, PdfFontFactory.EmbeddingStrategy
                .PREFER_NOT_EMBEDDED);
            NUnit.Framework.Assert.IsNotNull(font);
            NUnit.Framework.Assert.IsFalse(font.IsEmbedded());
        }

        [NUnit.Framework.Test]
        public virtual void StandardFontForceNotEmbeddedTest() {
            Type1Font fontProgram = (Type1Font)FontProgramFactory.CreateFont(StandardFonts.HELVETICA);
            PdfType1Font font = (PdfType1Font)PdfFontFactory.CreateFont(fontProgram, PdfEncodings.UTF8, PdfFontFactory.EmbeddingStrategy
                .FORCE_NOT_EMBEDDED);
            NUnit.Framework.Assert.IsNotNull(font);
            NUnit.Framework.Assert.IsFalse(font.IsEmbedded());
        }

        [NUnit.Framework.Test]
        public virtual void CustomType1FontForceEmbeddedTest() {
            Type1Font fontProgram = new PdfFontFactoryTest.CustomType1FontProgram();
            PdfType1Font font = (PdfType1Font)PdfFontFactory.CreateFont(fontProgram, PdfEncodings.UTF8, PdfFontFactory.EmbeddingStrategy
                .FORCE_EMBEDDED);
            NUnit.Framework.Assert.IsNotNull(font);
            NUnit.Framework.Assert.IsTrue(font.IsEmbedded());
        }

        [NUnit.Framework.Test]
        public virtual void CustomType1FontPreferEmbeddedTest() {
            Type1Font fontProgram = new PdfFontFactoryTest.CustomType1FontProgram();
            PdfType1Font font = (PdfType1Font)PdfFontFactory.CreateFont(fontProgram, PdfEncodings.UTF8, PdfFontFactory.EmbeddingStrategy
                .PREFER_EMBEDDED);
            NUnit.Framework.Assert.IsNotNull(font);
            NUnit.Framework.Assert.IsTrue(font.IsEmbedded());
        }

        [NUnit.Framework.Test]
        public virtual void CustomType1FontPreferNotEmbeddedTest() {
            Type1Font fontProgram = new PdfFontFactoryTest.CustomType1FontProgram();
            PdfType1Font font = (PdfType1Font)PdfFontFactory.CreateFont(fontProgram, PdfEncodings.UTF8, PdfFontFactory.EmbeddingStrategy
                .PREFER_NOT_EMBEDDED);
            NUnit.Framework.Assert.IsNotNull(font);
            NUnit.Framework.Assert.IsFalse(font.IsEmbedded());
        }

        [NUnit.Framework.Test]
        public virtual void CustomType1FontForceNotEmbeddedTest() {
            Type1Font fontProgram = new PdfFontFactoryTest.CustomType1FontProgram();
            PdfType1Font font = (PdfType1Font)PdfFontFactory.CreateFont(fontProgram, PdfEncodings.UTF8, PdfFontFactory.EmbeddingStrategy
                .FORCE_NOT_EMBEDDED);
            NUnit.Framework.Assert.IsNotNull(font);
            NUnit.Framework.Assert.IsFalse(font.IsEmbedded());
        }

        [NUnit.Framework.Test]
        public virtual void TrueTypeFontProgramUTF8AllowEmbeddingEncodingForceEmbeddedTest() {
            TrueTypeFont fontProgram = new PdfFontFactoryTest.CustomTrueTypeFontProgram(true);
            PdfTrueTypeFont font = (PdfTrueTypeFont)PdfFontFactory.CreateFont(fontProgram, PdfEncodings.UTF8, PdfFontFactory.EmbeddingStrategy
                .FORCE_EMBEDDED);
            NUnit.Framework.Assert.IsNotNull(font);
            NUnit.Framework.Assert.IsTrue(font.IsEmbedded());
        }

        [NUnit.Framework.Test]
        public virtual void TrueTypeFontProgramUTF8AllowEmbeddingEncodingPreferEmbeddedTest() {
            TrueTypeFont fontProgram = new PdfFontFactoryTest.CustomTrueTypeFontProgram(true);
            PdfTrueTypeFont font = (PdfTrueTypeFont)PdfFontFactory.CreateFont(fontProgram, PdfEncodings.UTF8, PdfFontFactory.EmbeddingStrategy
                .PREFER_EMBEDDED);
            NUnit.Framework.Assert.IsNotNull(font);
            NUnit.Framework.Assert.IsTrue(font.IsEmbedded());
        }

        [NUnit.Framework.Test]
        public virtual void TrueTypeFontProgramUTF8AllowEmbeddingEncodingPreferNotEmbeddedTest() {
            TrueTypeFont fontProgram = new PdfFontFactoryTest.CustomTrueTypeFontProgram(true);
            PdfTrueTypeFont font = (PdfTrueTypeFont)PdfFontFactory.CreateFont(fontProgram, PdfEncodings.UTF8, PdfFontFactory.EmbeddingStrategy
                .PREFER_NOT_EMBEDDED);
            NUnit.Framework.Assert.IsNotNull(font);
            NUnit.Framework.Assert.IsFalse(font.IsEmbedded());
        }

        [NUnit.Framework.Test]
        public virtual void TrueTypeFontProgramUTF8AllowEmbeddingEncodingForceNotEmbeddedTest() {
            TrueTypeFont fontProgram = new PdfFontFactoryTest.CustomTrueTypeFontProgram(true);
            PdfTrueTypeFont font = (PdfTrueTypeFont)PdfFontFactory.CreateFont(fontProgram, PdfEncodings.UTF8, PdfFontFactory.EmbeddingStrategy
                .FORCE_NOT_EMBEDDED);
            NUnit.Framework.Assert.IsNotNull(font);
            NUnit.Framework.Assert.IsFalse(font.IsEmbedded());
        }

        [NUnit.Framework.Test]
        public virtual void TrueTypeFontProgramUTF8NotAllowEmbeddingEncodingForceEmbeddedTest() {
            TrueTypeFont fontProgram = new PdfFontFactoryTest.CustomTrueTypeFontProgram(false);
            NUnit.Framework.Assert.That(() =>  {
                PdfFontFactory.CreateFont(fontProgram, PdfEncodings.UTF8, PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);
            }
            , NUnit.Framework.Throws.InstanceOf<PdfException>().With.Message.EqualTo(MessageFormatUtil.Format(PdfException.CannotBeEmbeddedDueToLicensingRestrictions, "CustomNameCustomStyle")))
;
        }

        [NUnit.Framework.Test]
        public virtual void TrueTypeFontProgramUTF8NotAllowEmbeddingEncodingPreferEmbeddedTest() {
            TrueTypeFont fontProgram = new PdfFontFactoryTest.CustomTrueTypeFontProgram(false);
            PdfTrueTypeFont font = (PdfTrueTypeFont)PdfFontFactory.CreateFont(fontProgram, PdfEncodings.UTF8, PdfFontFactory.EmbeddingStrategy
                .PREFER_EMBEDDED);
            NUnit.Framework.Assert.IsNotNull(font);
            NUnit.Framework.Assert.IsFalse(font.IsEmbedded());
        }

        [NUnit.Framework.Test]
        public virtual void TrueTypeFontProgramUTF8NotAllowEmbeddingEncodingPreferNotEmbeddedTest() {
            TrueTypeFont fontProgram = new PdfFontFactoryTest.CustomTrueTypeFontProgram(false);
            PdfTrueTypeFont font = (PdfTrueTypeFont)PdfFontFactory.CreateFont(fontProgram, PdfEncodings.UTF8, PdfFontFactory.EmbeddingStrategy
                .PREFER_NOT_EMBEDDED);
            NUnit.Framework.Assert.IsNotNull(font);
            NUnit.Framework.Assert.IsFalse(font.IsEmbedded());
        }

        [NUnit.Framework.Test]
        public virtual void TrueTypeFontProgramUTF8NotAllowEmbeddingEncodingForceNotEmbeddedTest() {
            TrueTypeFont fontProgram = new PdfFontFactoryTest.CustomTrueTypeFontProgram(false);
            PdfTrueTypeFont font = (PdfTrueTypeFont)PdfFontFactory.CreateFont(fontProgram, PdfEncodings.UTF8, PdfFontFactory.EmbeddingStrategy
                .FORCE_NOT_EMBEDDED);
            NUnit.Framework.Assert.IsNotNull(font);
            NUnit.Framework.Assert.IsFalse(font.IsEmbedded());
        }

        [NUnit.Framework.Test]
        public virtual void TrueTypeFontProgramIdentityHAllowEmbeddingEncodingForceEmbeddedTest() {
            TrueTypeFont fontProgram = new PdfFontFactoryTest.CustomTrueTypeFontProgram(true);
            PdfType0Font font = (PdfType0Font)PdfFontFactory.CreateFont(fontProgram, PdfEncodings.IDENTITY_H, PdfFontFactory.EmbeddingStrategy
                .FORCE_EMBEDDED);
            NUnit.Framework.Assert.IsNotNull(font);
            NUnit.Framework.Assert.IsTrue(font.IsEmbedded());
        }

        [NUnit.Framework.Test]
        public virtual void TrueTypeFontProgramIdentityHAllowEmbeddingEncodingPreferEmbeddedTest() {
            TrueTypeFont fontProgram = new PdfFontFactoryTest.CustomTrueTypeFontProgram(true);
            PdfType0Font font = (PdfType0Font)PdfFontFactory.CreateFont(fontProgram, PdfEncodings.IDENTITY_H, PdfFontFactory.EmbeddingStrategy
                .PREFER_EMBEDDED);
            NUnit.Framework.Assert.IsNotNull(font);
            NUnit.Framework.Assert.IsTrue(font.IsEmbedded());
        }

        [NUnit.Framework.Test]
        public virtual void TrueTypeFontProgramIdentityHAllowEmbeddingEncodingPreferNotEmbeddedTest() {
            TrueTypeFont fontProgram = new PdfFontFactoryTest.CustomTrueTypeFontProgram(true);
            PdfType0Font font = (PdfType0Font)PdfFontFactory.CreateFont(fontProgram, PdfEncodings.IDENTITY_H, PdfFontFactory.EmbeddingStrategy
                .PREFER_NOT_EMBEDDED);
            NUnit.Framework.Assert.IsNotNull(font);
            NUnit.Framework.Assert.IsTrue(font.IsEmbedded());
        }

        [NUnit.Framework.Test]
        public virtual void TrueTypeFontProgramIdentityHAllowEmbeddingEncodingForceNotEmbeddedTest() {
            TrueTypeFont fontProgram = new PdfFontFactoryTest.CustomTrueTypeFontProgram(true);
            NUnit.Framework.Assert.That(() =>  {
                PdfFontFactory.CreateFont(fontProgram, PdfEncodings.IDENTITY_H, PdfFontFactory.EmbeddingStrategy.FORCE_NOT_EMBEDDED
                    );
            }
            , NUnit.Framework.Throws.InstanceOf<PdfException>().With.Message.EqualTo(PdfException.CannotCreateType0FontWithTrueTypeFontProgramWithoutEmbedding))
;
        }

        [NUnit.Framework.Test]
        public virtual void TrueTypeFontProgramIdentityHNotAllowEmbeddingEncodingForceEmbeddedTest() {
            TrueTypeFont fontProgram = new PdfFontFactoryTest.CustomTrueTypeFontProgram(false);
            NUnit.Framework.Assert.That(() =>  {
                PdfFontFactory.CreateFont(fontProgram, PdfEncodings.IDENTITY_H, PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED
                    );
            }
            , NUnit.Framework.Throws.InstanceOf<PdfException>().With.Message.EqualTo(MessageFormatUtil.Format(PdfException.CannotBeEmbeddedDueToLicensingRestrictions, "CustomNameCustomStyle")))
;
        }

        [NUnit.Framework.Test]
        public virtual void TrueTypeFontProgramIdentityHNotAllowEmbeddingEncodingPreferEmbeddedTest() {
            TrueTypeFont fontProgram = new PdfFontFactoryTest.CustomTrueTypeFontProgram(false);
            NUnit.Framework.Assert.That(() =>  {
                PdfFontFactory.CreateFont(fontProgram, PdfEncodings.IDENTITY_H, PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED
                    );
            }
            , NUnit.Framework.Throws.InstanceOf<PdfException>().With.Message.EqualTo(MessageFormatUtil.Format(PdfException.CannotBeEmbeddedDueToLicensingRestrictions, "CustomNameCustomStyle")))
;
        }

        [NUnit.Framework.Test]
        public virtual void TrueTypeFontProgramIdentityHNotAllowEmbeddingEncodingPreferNotEmbeddedTest() {
            TrueTypeFont fontProgram = new PdfFontFactoryTest.CustomTrueTypeFontProgram(false);
            NUnit.Framework.Assert.That(() =>  {
                PdfFontFactory.CreateFont(fontProgram, PdfEncodings.IDENTITY_H, PdfFontFactory.EmbeddingStrategy.PREFER_NOT_EMBEDDED
                    );
            }
            , NUnit.Framework.Throws.InstanceOf<PdfException>().With.Message.EqualTo(MessageFormatUtil.Format(PdfException.CannotBeEmbeddedDueToLicensingRestrictions, "CustomNameCustomStyle")))
;
        }

        [NUnit.Framework.Test]
        public virtual void TrueTypeFontProgramIdentityHNotAllowEmbeddingEncodingForceNotEmbeddedTest() {
            TrueTypeFont fontProgram = new PdfFontFactoryTest.CustomTrueTypeFontProgram(false);
            NUnit.Framework.Assert.That(() =>  {
                PdfFontFactory.CreateFont(fontProgram, PdfEncodings.IDENTITY_H, PdfFontFactory.EmbeddingStrategy.FORCE_NOT_EMBEDDED
                    );
            }
            , NUnit.Framework.Throws.InstanceOf<PdfException>().With.Message.EqualTo(MessageFormatUtil.Format(PdfException.CannotBeEmbeddedDueToLicensingRestrictions, "CustomNameCustomStyle")))
;
        }

        [NUnit.Framework.Test]
        public virtual void StandardFontCachedWithoutDocumentTest() {
            // this test ensures that method which allows caching into the document does not fail
            // if the document is null
            PdfDocument cacheTo = null;
            PdfType1Font font = (PdfType1Font)PdfFontFactory.CreateFont(StandardFonts.HELVETICA, PdfEncodings.UTF8, cacheTo
                );
            NUnit.Framework.Assert.IsNotNull(font);
            NUnit.Framework.Assert.IsFalse(font.IsEmbedded());
        }

        [NUnit.Framework.Test]
        public virtual void CreateFontFromNullDictionaryTest() {
            PdfDictionary dictionary = null;
            NUnit.Framework.Assert.That(() =>  {
                PdfFontFactory.CreateFont(dictionary);
            }
            , NUnit.Framework.Throws.InstanceOf<PdfException>().With.Message.EqualTo(PdfException.CannotCreateFontFromNullFontDictionary))
;
        }

        [NUnit.Framework.Test]
        public virtual void CreateFontFromEmptyDictionaryTest() {
            PdfDictionary dictionary = new PdfDictionary();
            NUnit.Framework.Assert.That(() =>  {
                PdfFontFactory.CreateFont(dictionary);
            }
            , NUnit.Framework.Throws.InstanceOf<PdfException>().With.Message.EqualTo(PdfException.DictionaryDoesntHaveSupportedFontData))
;
        }

        [NUnit.Framework.Test]
        public virtual void DeprecatedEmbeddedFlagTrueWorksAsPreferEmbeddedTest() {
            // simply checks that embedded = true works as prefer embedded
            // this test can be safely removed with clean up of deprecated methods in PdfFontFactory
            PdfType1Font font = (PdfType1Font)PdfFontFactory.CreateFont(StandardFonts.HELVETICA, true);
            NUnit.Framework.Assert.IsNotNull(font);
            NUnit.Framework.Assert.IsFalse(font.IsEmbedded());
        }

        [NUnit.Framework.Test]
        public virtual void DeprecatedEmbeddedFlagFalseWorksAsPreferNotEmbeddedTest() {
            // simply checks that embedded = false works as prefer not embedded
            // this test can be safely removed with clean up of deprecated methods in PdfFontFactory
            TrueTypeFont fontProgram = new PdfFontFactoryTest.CustomTrueTypeFontProgram(true);
            PdfType0Font font = (PdfType0Font)PdfFontFactory.CreateFont(fontProgram, PdfEncodings.IDENTITY_H, false);
            NUnit.Framework.Assert.IsNotNull(font);
            NUnit.Framework.Assert.IsTrue(font.IsEmbedded());
        }

        private class CustomType1FontProgram : Type1Font {
            public override bool IsBuiltInFont() {
                return false;
            }
        }

        private class CustomTrueTypeFontProgram : TrueTypeFont {
            public CustomTrueTypeFontProgram(bool allowEmbedding) {
                this.fontNames = new PdfFontFactoryTest.CustomFontNames(allowEmbedding);
            }
        }

        private class CustomFontNames : FontNames {
            public CustomFontNames(bool allowEmbedding) {
                this.SetAllowEmbedding(allowEmbedding);
                this.SetFontName("CustomName");
                this.SetStyle("CustomStyle");
            }
        }
    }
}
