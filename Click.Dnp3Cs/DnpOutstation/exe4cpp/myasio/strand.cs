﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * strand.h
 *
 *  Created on: Jun 1, 2023
 *      Author: Reza
 */


namespace asio
{
	//template <typename t>

	public class strand : System.IDisposable
	{
		public strand()
		{



		}

//		 return_from<t>() {
//		//	t y;
////			return y;
//		}
	public virtual void Dispose()
	{
	}

//template <typename handler_t>
//    asio::detail::wrapped_handler<asio::strand, handler_t, asio::detail::is_continuation_if_running> wrap(const handler_t& handler)
//    {
//        return strand.wrap(handler);
//    }
	}

} // namespace asio




	//namespace asio {

	//    /// Provides serialised function invocation for any executor type.
	//    template <typename Executor>
	//    class strand
	//    {
	//    public:
	//        /// The type of the underlying executor.
	//        typedef Executor inner_executor_type;

	//        /// Default constructor.
	//        /**
	//         * This constructor is only valid if the underlying executor type is default
	//         * constructible.
	//         */
	//        strand()
	//            : executor_(),
	//            impl_(use_service<detail::strand_executor_service>(
	//                executor_.context()).create_implementation())
	//        {
	//        }

	//        /// Construct a strand for the specified executor.
	//        explicit strand(const Executor& e)
	//            : executor_(e),
	//            impl_(use_service<detail::strand_executor_service>(
	//                executor_.context()).create_implementation())
	//        {
	//        }

	//        /// Copy constructor.
	//        strand(const strand& other) BOOST_ASIO_NOEXCEPT
	//            : executor_(other.executor_),
	//            impl_(other.impl_)
	//        {
	//        }

	//        /// Converting constructor.
	//        /**
	//         * This constructor is only valid if the @c OtherExecutor type is convertible
	//         * to @c Executor.
	//         */
	//        template <class OtherExecutor>
	//        strand(
	//            const strand<OtherExecutor>& other) BOOST_ASIO_NOEXCEPT
	//            : executor_(other.executor_),
	//            impl_(other.impl_)
	//        {
	//        }

	//        /// Assignment operator.
	//        strand& operator=(const strand& other) BOOST_ASIO_NOEXCEPT
	//        {
	//            executor_ = other.executor_;
	//            impl_ = other.impl_;
	//            return *this;
	//        }

	//        /// Converting assignment operator.
	//        /**
	//         * This assignment operator is only valid if the @c OtherExecutor type is
	//         * convertible to @c Executor.
	//         */
	//        template <class OtherExecutor>
	//        strand& operator=(
	//            const strand<OtherExecutor>& other) BOOST_ASIO_NOEXCEPT
	//        {
	//            executor_ = other.executor_;
	//            impl_ = other.impl_;
	//            return *this;
	//        }

	//        /// Destructor.
	//        ~strand()
	//        {
	//        }

	//        /// Obtain the underlying executor.
	//        inner_executor_type get_inner_executor() const BOOST_ASIO_NOEXCEPT
	//        {
	//            return executor_;
	//        }

	//        /// Obtain the underlying execution context.
	//        execution_context& context() const BOOST_ASIO_NOEXCEPT
	//        {
	//            return executor_.context();
	//        }

	//        /// Inform the strand that it has some outstanding work to do.
	//        /**
	//         * The strand delegates this call to its underlying executor.
	//         */
	//        void on_work_started() const BOOST_ASIO_NOEXCEPT
	//        {
	//            executor_.on_work_started();
	//        }

	//        /// Inform the strand that some work is no longer outstanding.
	//        /**
	//         * The strand delegates this call to its underlying executor.
	//         */
	//        void on_work_finished() const BOOST_ASIO_NOEXCEPT
	//        {
	//            executor_.on_work_finished();
	//        }

	//        /// Request the strand to invoke the given function object.
	//        /**
	//         * This function is used to ask the strand to execute the given function
	//         * object on its underlying executor. The function object will be executed
	//         * inside this function if the strand is not otherwise busy and if the
	//         * underlying executor's @c dispatch() function is also able to execute the
	//         * function before returning.
	//         *
	//         * @param f The function object to be called. The executor will make
	//         * a copy of the handler object as required. The function signature of the
	//         * function object must be: @code void function(); @endcode
	//         *
	//         * @param a An allocator that may be used by the executor to allocate the
	//         * internal storage needed for function invocation.
	//         */
	//        template <typename Function, typename Allocator>
	//        void dispatch(BOOST_ASIO_MOVE_ARG(Function) f, const Allocator& a) const
	//        {
	//            detail::strand_executor_service::dispatch(impl_,
	//                executor_, BOOST_ASIO_MOVE_CAST(Function)(f), a);
	//        }

	//        /// Request the strand to invoke the given function object.
	//        /**
	//         * This function is used to ask the executor to execute the given function
	//         * object. The function object will never be executed inside this function.
	//         * Instead, it will be scheduled by the underlying executor's defer function.
	//         *
	//         * @param f The function object to be called. The executor will make
	//         * a copy of the handler object as required. The function signature of the
	//         * function object must be: @code void function(); @endcode
	//         *
	//         * @param a An allocator that may be used by the executor to allocate the
	//         * internal storage needed for function invocation.
	//         */
	//        template <typename Function, typename Allocator>
	//        void post(BOOST_ASIO_MOVE_ARG(Function) f, const Allocator& a) const
	//        {
	//            detail::strand_executor_service::post(impl_,
	//                executor_, BOOST_ASIO_MOVE_CAST(Function)(f), a);
	//        }

	//        /// Request the strand to invoke the given function object.
	//        /**
	//         * This function is used to ask the executor to execute the given function
	//         * object. The function object will never be executed inside this function.
	//         * Instead, it will be scheduled by the underlying executor's defer function.
	//         *
	//         * @param f The function object to be called. The executor will make
	//         * a copy of the handler object as required. The function signature of the
	//         * function object must be: @code void function(); @endcode
	//         *
	//         * @param a An allocator that may be used by the executor to allocate the
	//         * internal storage needed for function invocation.
	//         */
	//        template <typename Function, typename Allocator>
	//        void defer(BOOST_ASIO_MOVE_ARG(Function) f, const Allocator& a) const
	//        {
	//            detail::strand_executor_service::defer(impl_,
	//                executor_, BOOST_ASIO_MOVE_CAST(Function)(f), a);
	//        }

	//        /// Determine whether the strand is running in the current thread.
	//        /**
	//         * @return @c true if the current thread is executing a function that was
	//         * submitted to the strand using post(), dispatch() or defer(). Otherwise
	//         * returns @c false.
	//         */
	//        bool running_in_this_thread() const BOOST_ASIO_NOEXCEPT
	//        {
	//            return detail::strand_executor_service::running_in_this_thread(impl_);
	//        }

	//        /// Compare two strands for equality.
	//        /**
	//         * Two strands are equal if they refer to the same ordered, non-concurrent
	//         * state.
	//         */
	//        friend bool operator==(const strand& a, const strand& b) BOOST_ASIO_NOEXCEPT
	//        {
	//            return a.impl_ == b.impl_;
	//        }

	//        /// Compare two strands for inequality.
	//        /**
	//         * Two strands are equal if they refer to the same ordered, non-concurrent
	//         * state.
	//         */
	//        friend bool operator!=(const strand& a, const strand& b) BOOST_ASIO_NOEXCEPT
	//        {
	//            return a.impl_ != b.impl_;
	//        }

	//    private:
	//        Executor executor_;
	//        typedef detail::strand_executor_service::implementation_type
	//            implementation_type;
	//        implementation_type impl_;
	//    };

	//    /** @defgroup make_strand boost::asio::make_strand
	//     *
	//     * @brief The boost::asio::make_strand function creates a @ref strand object for
	//     * an executor or execution context.
	//     */
	//     /*@{*/

	//     /// Create a @ref strand object for an executor.
	//    template <typename Executor>
	//    inline strand<Executor> make_strand(const Executor& ex,
	//        typename enable_if<is_executor<Executor>::value>::type* = 0)
	//    {
	//        return strand<Executor>(ex);
	//    }

	//    /// Create a @ref strand object for an execution context.
	//    template <typename ExecutionContext>
	//    inline strand<typename ExecutionContext::executor_type>
	//        make_strand(ExecutionContext& ctx,
	//            typename enable_if<
	//            is_convertible<ExecutionContext&, execution_context&>::value>::type* = 0)
	//    {
	//        return strand<typename ExecutionContext::executor_type>(ctx.get_executor());
	//    }

	//    /*@}*/

	//} // namespace asio
