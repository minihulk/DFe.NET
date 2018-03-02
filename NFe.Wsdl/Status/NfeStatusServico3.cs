﻿/********************************************************************************/
/* Projeto: Biblioteca ZeusNFe                                                  */
/* Biblioteca C# para emissão de Nota Fiscal Eletrônica - NFe e Nota Fiscal de  */
/* Consumidor Eletrônica - NFC-e (http://www.nfe.fazenda.gov.br)                */
/*                                                                              */
/* Direitos Autorais Reservados (c) 2014 Adenilton Batista da Silva             */
/*                                       Zeusdev Tecnologia LTDA ME             */
/*                                                                              */
/*  Você pode obter a última versão desse arquivo no GitHub                     */
/* localizado em https://github.com/adeniltonbs/Zeus.Net.NFe.NFCe               */
/*                                                                              */
/*                                                                              */
/*  Esta biblioteca é software livre; você pode redistribuí-la e/ou modificá-la */
/* sob os termos da Licença Pública Geral Menor do GNU conforme publicada pela  */
/* Free Software Foundation; tanto a versão 2.1 da Licença, ou (a seu critério) */
/* qualquer versão posterior.                                                   */
/*                                                                              */
/*  Esta biblioteca é distribuída na expectativa de que seja útil, porém, SEM   */
/* NENHUMA GARANTIA; nem mesmo a garantia implícita de COMERCIABILIDADE OU      */
/* ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA. Consulte a Licença Pública Geral Menor*/
/* do GNU para mais detalhes. (Arquivo LICENÇA.TXT ou LICENSE.TXT)              */
/*                                                                              */
/*  Você deve ter recebido uma cópia da Licença Pública Geral Menor do GNU junto*/
/* com esta biblioteca; se não, escreva para a Free Software Foundation, Inc.,  */
/* no endereço 59 Temple Street, Suite 330, Boston, MA 02111-1307 USA.          */
/* Você também pode obter uma copia da licença em:                              */
/* http://www.opensource.org/licenses/lgpl-license.php                          */
/*                                                                              */
/* Zeusdev Tecnologia LTDA ME - adenilton@zeusautomacao.com.br                  */
/* http://www.zeusautomacao.com.br/                                             */
/* Rua Comendador Francisco josé da Cunha, 111 - Itabaiana - SE - 49500-000     */
/********************************************************************************/
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace NFe.Wsdl.Status
{
    public class NfeStatusServico3 : NfeStatusServico3Soap12Client, INfeServico
    {
        public NfeStatusServico3(string url, X509Certificate certificado, int timeOut) : base(url)
        {
            base.ClientCredentials.ClientCertificate.Certificate = (X509Certificate2)certificado;
        }

        public nfeCabecMsg nfeCabecMsg { get; set; }

        public XmlNode Execute(XmlNode nfeDadosMsg)
        {
            var result = base.nfeStatusServicoNF3Async(this.nfeCabecMsg, nfeDadosMsg).Result;
            return result.nfeStatusServicoNF3Result;
        }
    }

    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NfeStatusServico3", ConfigurationName = "NfeStatusServico3Soap12")]
    public interface NfeStatusServico3Soap12 : IChannel
    {
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.portalfiscal.inf.br/nfe/wsdl/NfeStatusServico3/nfeStatusServicoNF", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        System.Threading.Tasks.Task<nfeStatusServicoNF3Response> nfeStatusServicoNF3Async(nfeStatusServicoNF3Request request);
    }

    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class nfeStatusServicoNF3Request
    {

        [System.ServiceModel.MessageHeaderAttribute(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NfeStatusServico3")]
        public nfeCabecMsg nfeCabecMsg;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NfeStatusServico3", Order = 0)]
        public System.Xml.XmlNode nfeDadosMsg;

        public nfeStatusServicoNF3Request()
        {
        }

        public nfeStatusServicoNF3Request(nfeCabecMsg nfeCabecMsg, System.Xml.XmlNode nfeDadosMsg)
        {
            this.nfeCabecMsg = nfeCabecMsg;
            this.nfeDadosMsg = nfeDadosMsg;
        }
    }

    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class nfeStatusServicoNF3Response
    {

        [System.ServiceModel.MessageHeaderAttribute(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NfeStatusServico3")]
        public nfeCabecMsg nfeCabecMsg;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NfeStatusServico3", Order = 0)]
        public System.Xml.XmlNode nfeStatusServicoNF3Result;

        public nfeStatusServicoNF3Response()
        {
        }

        public nfeStatusServicoNF3Response(nfeCabecMsg nfeCabecMsg, System.Xml.XmlNode nfeStatusServicoNF3Result)
        {
            this.nfeCabecMsg = nfeCabecMsg;
            this.nfeStatusServicoNF3Result = nfeStatusServicoNF3Result;
        }
    }

    public partial class NfeStatusServico3Soap12Client : SoapBindingClient<NfeStatusServico3Soap12>
    {
        public NfeStatusServico3Soap12Client(string endpointAddressUri) : base(endpointAddressUri)
        {
        }

        public System.Threading.Tasks.Task<nfeStatusServicoNF3Response> nfeStatusServicoNF3Async(nfeCabecMsg nfeCabecMsg, System.Xml.XmlNode nfeDadosMsg)
        {
            nfeStatusServicoNF3Request inValue = new nfeStatusServicoNF3Request();
            inValue.nfeCabecMsg = nfeCabecMsg;
            inValue.nfeDadosMsg = nfeDadosMsg;
            return ((NfeStatusServico3Soap12)(this.Channel)).nfeStatusServicoNF3Async(inValue);
        }
    }
}