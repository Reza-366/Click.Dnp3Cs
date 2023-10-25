/*
 * Copyright 2013-2022 Step Function I/O, LLC
 *
 * Licensed to Green Energy Corp (www.greenenergycorp.com) and Step Function I/O
 * LLC (https://stepfunc.io) under one or more contributor license agreements.
 * See the NOTICE file distributed with this work for additional information
 * regarding copyright ownership. Green Energy Corp and Step Function I/O LLC license
 * this file to you under the Apache License, Version 2.0 (the "License"); you
 * may not use this file except in compliance with the License. You may obtain
 * a copy of the License at:
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */



namespace opendnp3
{

/**
 * TLS configuration information
 */
public class TLSConfig
{
	/**
	 * Construct a TLS configuration
	 *
	 * @param peerCertFilePath Certificate file used to verify the peer or server. Can be CA file or a self-signed cert
	 * provided by other party.
	 * @param localCertFilePath File that contains the certificate (or certificate chain) that will be presented to the
	 * remote side of the connection
	 * @param privateKeyFilePath File that contains the private key corresponding to the local certificate
	 * @param allowTLSv10 Allow TLS version 1.0 (default false)
	 * @param allowTLSv11 Allow TLS version 1.1 (default false)
	 * @param allowTLSv12 Allow TLS version 1.2 (default true)
	 * @param allowTLSv13 Allow TLS version 1.3 (default true)
	 * @param cipherList The openssl cipher-list, defaults to "" which does not modify the default cipher list
	 *
	 * localCertFilePath and privateKeyFilePath can optionally be the same file, i.e. a PEM that contains both pieces of
	 * data.
	 *
	 */
	public TLSConfig(in string peerCertFilePath, in string localCertFilePath, in string privateKeyFilePath, bool allowTLSv10 = false, bool allowTLSv11 = false, bool allowTLSv12 = true, bool allowTLSv13 = true, in string cipherList = "")
	{
		this.peerCertFilePath = peerCertFilePath;
		this.localCertFilePath = localCertFilePath;
		this.privateKeyFilePath = privateKeyFilePath;
		this.allowTLSv10 = allowTLSv10;
		this.allowTLSv11 = allowTLSv11;
		this.allowTLSv12 = allowTLSv12;
		this.allowTLSv13 = allowTLSv13;
		this.cipherList = cipherList;
	}

	/// Certificate file used to verify the peer or server. Can be CA file or a self-signed cert provided by other
	/// party.
	public string peerCertFilePath = "";

	/// File that contains the certificate (or certificate chain) that will be presented to the remote side of the
	/// connection
	public string localCertFilePath = "";

	/// File that contains the private key corresponding to the local certificate
	public string privateKeyFilePath = "";

	/// Allow TLS version 1.0 (default false)
	public bool allowTLSv10;

	/// Allow TLS version 1.1 (default false)
	public bool allowTLSv11;

	/// Allow TLS version 1.2 (default true)
	public bool allowTLSv12;

	/// Allow TLS version 1.3 (default true)
	public bool allowTLSv13;

	/// openssl format cipher list
	public string cipherList = "";
}

} // namespace opendnp3

