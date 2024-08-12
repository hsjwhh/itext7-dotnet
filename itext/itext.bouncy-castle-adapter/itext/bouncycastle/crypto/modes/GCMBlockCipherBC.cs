/*
This file is part of the iText (R) project.
Copyright (c) 1998-2024 Apryse Group NV
Authors: Apryse Software.

This program is offered under a commercial and under the AGPL license.
For commercial licensing, contact us at https://itextpdf.com/sales.  For AGPL licensing, see below.

AGPL licensing:
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
using System;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using iText.Commons.Bouncycastle.Crypto.Modes;
using iText.Commons.Utils;

namespace iText.Bouncycastle.Crypto.Modes {
    public class GCMBlockCipherBC : IGCMBlockCipher {
        private readonly GcmBlockCipher cipher;

        public GCMBlockCipherBC(GcmBlockCipher cipher) {
            this.cipher = cipher;
        }

        public virtual GcmBlockCipher GetCipher() {
            return cipher;
        }

        public virtual void Init(bool forEncryption, byte[] key, int macSizeBits, byte[] iv) {
            cipher.Init(forEncryption, new AeadParameters(new KeyParameter(key), macSizeBits, iv));
        }

        public virtual int GetUpdateOutputSize(int len) {
            return cipher.GetUpdateOutputSize(len);
        }

        public virtual void ProcessBytes(byte[] inputBuff, int inOff, int len, byte[] outBuff, int outOff) {
            cipher.ProcessBytes(inputBuff, inOff, len, outBuff, outOff);
        }

        public virtual int GetOutputSize(int i) {
            return cipher.GetOutputSize(i);
        }

        public virtual void DoFinal(byte[] plainText, int i) {
            try {
                cipher.DoFinal(plainText, i);
            }
            catch (InvalidCipherTextException e) {
                throw new InvalidCipherTextExceptionBC(e);
            }
        }

        public override bool Equals(Object o) {
            if (this == o) {
                return true;
            }
            if (o == null || GetType() != o.GetType()) {
                return false;
            }
            iText.Bouncycastle.Crypto.Modes.GCMBlockCipherBC that = (iText.Bouncycastle.Crypto.Modes.GCMBlockCipherBC)
                o;
            return Object.Equals(cipher, that.cipher);
        }

        public override int GetHashCode() {
            return JavaUtil.ArraysHashCode(cipher);
        }

        public override String ToString() {
            return cipher.ToString();
        }
    }
}
