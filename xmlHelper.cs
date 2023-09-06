    public static class XmlHelper
    {
        public static T ToObject<T>(string conteudoXml)
        {
            var ser = new XmlSerializer(typeof(T));
            StringReader xmlReader = new StringReader(conteudoXml);
            return (T)ser.Deserialize(xmlReader);
        }

        /// <summary>
        /// Serializar objeto.
        /// </summary>
        /// <param name="objClasse"></param>
        /// <returns></returns>
        public static string ToXml(object objClasse)
        {
            StringWriter writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(objClasse.GetType());
            serializer.Serialize(writer, objClasse);
            return writer.ToString();
        }

        /// <summary>
        /// Serializar para XML sem declaração e namespaces
        /// </summary>
        /// <param name="objClasse"></param>
        /// <returns></returns>
        public static string ToXmlFlat(object objClasse)
        {
            var stringWriter = new StringWriter();

            var xmlWritterSettings =
                new XmlWriterSettings
                {
                    OmitXmlDeclaration = true,
                    CloseOutput = true
                };

            using (var xmlWriter = XmlWriter.Create(stringWriter, xmlWritterSettings))
            {
                var xmlSerializer = new XmlSerializer(objClasse.GetType());

                //Incluir namespace vazio para não renderizar nada
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                xmlSerializer.Serialize(xmlWriter, objClasse, ns);

                return stringWriter.ToString();
            }
        }

        public static string ToXmlFlatInnerXml(object objClasse)
        {
            string objXml = ToXmlFlat(objClasse);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(objXml);
            return doc.DocumentElement.InnerXml;
        }

        public static string XmlDecode(string xml)
        {
            return HttpUtility.HtmlDecode(xml);
        }

        public static string CleanInvalidXmlChars(string strXML)
        {
            string re = @"[^\x09\x0A\x0D\x20-\xD7FF\xE000-\xFFFD\x10000-x10FFFF]";
            string result = string.Empty;
            result = strXML;

            result = Regex.Replace(result, re, string.Empty);

            result = result.Replace("&#x0;", "");
            result = result.Replace("&#x1;", "");
            result = result.Replace("&#x2;", "");
            result = result.Replace("&#x3;", "");
            result = result.Replace("&#x4;", "");
            result = result.Replace("&#x5;", "");
            result = result.Replace("&#x6;", "");
            result = result.Replace("&#x7;", "");
            result = result.Replace("&#x8;", "");
            result = result.Replace("&#x9;", "");
            result = result.Replace("&#xa;", "");
            result = result.Replace("&#xb;", "");
            result = result.Replace("&#xc;", "");
            result = result.Replace("&#xd;", "");
            result = result.Replace("&#xe;", "");
            result = result.Replace("&#xf;", "");
            result = result.Replace("&#x10;", "");
            result = result.Replace("&#x11;", "");
            result = result.Replace("&#x12;", "");
            result = result.Replace("&#x13;", "");
            result = result.Replace("&#x14;", "");
            result = result.Replace("&#x15;", "");
            result = result.Replace("&#x16;", "");
            result = result.Replace("&#x17;", "");
            result = result.Replace("&#x18;", "");
            result = result.Replace("&#x19;", "");
            result = result.Replace("&#x1a;", "");
            result = result.Replace("&#x1b;", "");
            result = result.Replace("&#x1c;", "");
            result = result.Replace("&#x1d;", "");
            result = result.Replace("&#x1e;", "");
            result = result.Replace("&#x1f;", "");
            result = result.Replace("&#xA;", "");
            result = result.Replace("&#xB;", "");
            result = result.Replace("&#xC;", "");
            result = result.Replace("&#xD;", "");
            result = result.Replace("&#xE;", "");
            result = result.Replace("&#xF;", "");
            result = result.Replace("&#x1A;", "");
            result = result.Replace("&#x1B;", "");
            result = result.Replace("&#x1C;", "");
            result = result.Replace("&#x1D;", "");
            result = result.Replace("&#x1E;", "");
            result = result.Replace("&#x1F;", "");

            return result;
        }
}
