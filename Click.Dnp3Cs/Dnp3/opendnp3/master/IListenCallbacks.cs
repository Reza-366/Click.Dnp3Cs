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
 * Callback interface invoked when a new connection is accepted
 */
public abstract class IListenCallbacks : System.IDisposable
{
	public virtual void Dispose()
	{
	}

	/**
	 * Ask user code if the following connection should be accepted
	 *
	 * @param sessionid Incrementing id used to uniquely identify the session
	 * @param ipaddress The IP address of the connecting host. Can optionally be used for connection filtering
	 *
	 * @return If true, the connection is accepted and a link frame parser is created to handle incoming frame data
	 */
	public abstract bool AcceptConnection(uint64_t sessionid, in string ipaddress);

	/**
	 * Ask user code if the following preverified certificate should be accepted
	 *
	 * @param sessionid Incrementing id used to uniquely identify the session
	 * @param info Information from the x509 certificate
	 *
	 * @return If true, if the certificate should be accepted, false otherwise.
	 */
	public abstract bool AcceptCertificate(uint64_t sessionid, in X509Info info);

	/// return the amount of time the session should wait for the first frame
	public abstract TimeDuration GetFirstFrameTimeout();

	/**
	 * Called when the first link-layer frame is received for a session
	 */
	public abstract void OnFirstFrame(uint64_t sessionid, in LinkHeaderFields header, ISessionAcceptor acceptor);

	/**
	 * Called when a socket closes
	 *
	 * @param sessionid Incrementing id used to uniquely identify the session
	 * @param session Possibly NULL shared_ptr to the master session if it was created
	 */
	public abstract void OnConnectionClose(uint64_t sessionid, IMasterSession session);

	/**
	 * Called when a certificate fails verification
	 *
	 * @param sessionid Incrementing id used to uniquely identify the session
	 * @param info Information from the x509 certificate
	 * @param error Error code with reason for failed verification
	 */
	public abstract void OnCertificateError(uint64_t sessionid, in X509Info info, int error);
}

} // namespace opendnp3

