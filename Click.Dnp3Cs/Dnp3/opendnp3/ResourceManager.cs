using System.Collections.Generic;

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

public sealed class ResourceManager : IResourceManager
{

	public static ResourceManager Create()
	{
		return new ResourceManager();
	}

	public override void Detach(IResource resource)
	{
	//    std::lock_guard<std::mutex> lock(this->mutex);
	//    this->resources.erase(resource);
	}

	public void Shutdown()
	{
	//    std::set<std::shared_ptr<IResource>> copy;
	//
	//    {
	//        std::lock_guard<std::mutex> lock(this->mutex);
	//        this->is_shutting_down = true;
	//        for (auto& resource : this->resources)
	//        {
	//            copy.insert(resource);
	//        }
	//        resources.clear();
	//    }
	//
	//    for (auto& resource : copy)
	//    {
	//        resource->Shutdown();
	//    }
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class R, class T>
	public R Bind<R, T>(in T create)
	{
//        std::lock_guard<std::mutex> lock(this->mutex); //REZA
//        if (this->is_shutting_down)
//        {
//            return nullptr;
//        }
//        else
//        {
//            auto item = create();
//            if (item)
//            {
//                this->resources.insert(item);
//            }
//            return item;
//        }
		R ptr;
		return ptr;
	}

//    std::mutex mutex;  //REZA
	private bool is_shutting_down = false;
	private SortedSet<IResource> resources = new SortedSet<IResource>();
}

} // namespace opendnp3



