/*
This file is part of the iText (R) project.
Copyright (c) 1998-2022 iText Group NV
Authors: iText Software.

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
using Org.BouncyCastle.Cert.Jcajce;
using iText.Bouncycastle.Cert;
using iText.Commons.Bouncycastle.Cert.Jcajce;

namespace iText.Bouncycastle.Cert.Jcajce {
    /// <summary>
    /// Wrapper class for
    /// <see cref="Org.BouncyCastle.Cert.Jcajce.JcaX509CertificateHolder"/>.
    /// </summary>
    public class JcaX509CertificateHolderBC : X509CertificateHolderBC, IJcaX509CertificateHolder {
        /// <summary>
        /// Creates new wrapper instance for
        /// <see cref="Org.BouncyCastle.Cert.Jcajce.JcaX509CertificateHolder"/>.
        /// </summary>
        /// <param name="certificateHolder">
        /// 
        /// <see cref="Org.BouncyCastle.Cert.Jcajce.JcaX509CertificateHolder"/>
        /// to be wrapped
        /// </param>
        public JcaX509CertificateHolderBC(JcaX509CertificateHolder certificateHolder)
            : base(certificateHolder) {
        }

        /// <summary>Gets actual org.bouncycastle object being wrapped.</summary>
        /// <returns>
        /// wrapped
        /// <see cref="Org.BouncyCastle.Cert.Jcajce.JcaX509CertificateHolder"/>.
        /// </returns>
        public virtual JcaX509CertificateHolder GetJcaCertificateHolder() {
            return (JcaX509CertificateHolder)GetCertificateHolder();
        }
    }
}
