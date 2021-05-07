/*
This file is part of the iText (R) project.
Copyright (c) 1998-2021 iText Group NV
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
using System;
using System.Collections.Generic;
using Common.Logging;
using iText.IO.Util;
using iText.Kernel;
using iText.Kernel.Actions;
using iText.Kernel.Actions.Processors;
using iText.Kernel.Actions.Producer;
using iText.Kernel.Actions.Session;
using iText.Kernel.Pdf;

namespace iText.Kernel.Actions.Events {
    /// <summary>
    /// Class represents events notifying that
    /// <see cref="iText.Kernel.Pdf.PdfDocument"/>
    /// was flushed.
    /// </summary>
    public sealed class FlushPdfDocumentEvent : AbstractITextConfigurationEvent {
        private static readonly ILog LOGGER = LogManager.GetLogger(typeof(iText.Kernel.Actions.Events.FlushPdfDocumentEvent
            ));

        private const String FLUSH_DOCUMENT_TYPE = "flush-document-event";

        private readonly WeakReference document;

        /// <summary>Creates a new instance of the flushing event.</summary>
        /// <param name="document">is a document to be flushed</param>
        public FlushPdfDocumentEvent(PdfDocument document)
            : base() {
            this.document = new WeakReference(document);
        }

        /// <summary><inheritDoc/></summary>
        /// <returns>
        /// 
        /// <inheritDoc/>
        /// </returns>
        public override String GetProductName() {
            return ProductNameConstant.ITEXT_CORE;
        }

        /// <summary>Returns a type of flushing event.</summary>
        /// <returns>
        /// 
        /// <inheritDoc/>
        /// </returns>
        public override String GetEventType() {
            return FLUSH_DOCUMENT_TYPE;
        }

        /// <summary>Prepares document for flushing.</summary>
        protected internal override void DoAction() {
            PdfDocument pdfDocument = (PdfDocument)document.Target;
            if (pdfDocument == null) {
                return;
            }
            IList<ITextProductEventWrapper> events = GetEvents(pdfDocument.GetDocumentIdWrapper());
            ICollection<String> products = new HashSet<String>();
            if (events == null || events.IsEmpty()) {
                return;
            }
            foreach (ITextProductEventWrapper @event in events) {
                products.Add(@event.GetEvent().GetProductName());
            }
            IDictionary<String, ITextProductEventProcessor> knownProducts = new Dictionary<String, ITextProductEventProcessor
                >();
            foreach (String product in products) {
                ITextProductEventProcessor processor = GetProcessor(product);
                if (processor == null) {
                    if (LOGGER.IsWarnEnabled) {
                        LOGGER.Warn(MessageFormatUtil.Format(KernelLogMessageConstant.UNKNOWN_PRODUCT_INVOLVED, product));
                    }
                }
                else {
                    knownProducts.Put(product, processor);
                }
            }
            String oldProducer = pdfDocument.GetDocumentInfo().GetProducer();
            String newProducer = ProducerBuilder.ModifyProducer(events, oldProducer);
            pdfDocument.GetDocumentInfo().SetProducer(newProducer);
            ClosingSession session = new ClosingSession((PdfDocument)document.Target);
            foreach (KeyValuePair<String, ITextProductEventProcessor> product in knownProducts) {
                product.Value.AggregationOnClose(session);
            }
            // do not join these loops into one as order of processing is important!
            foreach (KeyValuePair<String, ITextProductEventProcessor> product in knownProducts) {
                product.Value.CompletionOnClose(session);
            }
        }
    }
}
