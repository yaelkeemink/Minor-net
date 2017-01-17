// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Minor.Case1.FrontEnd.FrontEnd.Agents
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Models;

    /// <summary>
    /// Extension methods for CursusInstantieService.
    /// </summary>
    public static partial class CursusInstantieServiceExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cursist'>
            /// </param>
            public static object PostCursist(this ICursusInstantieService operations, Cursist cursist = default(Cursist))
            {
                return Task.Factory.StartNew(s => ((ICursusInstantieService)s).PostCursistAsync(cursist), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cursist'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> PostCursistAsync(this ICursusInstantieService operations, Cursist cursist = default(Cursist), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.PostCursistWithHttpMessagesAsync(cursist, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static Cursus GetAllCursusen(this ICursusInstantieService operations)
            {
                return Task.Factory.StartNew(s => ((ICursusInstantieService)s).GetAllCursusenAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Cursus> GetAllCursusenAsync(this ICursusInstantieService operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetAllCursusenWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='value'>
            /// </param>
            public static object PostCursusen(this ICursusInstantieService operations, Cursus value = default(Cursus))
            {
                return Task.Factory.StartNew(s => ((ICursusInstantieService)s).PostCursusenAsync(value), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='value'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> PostCursusenAsync(this ICursusInstantieService operations, Cursus value = default(Cursus), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.PostCursusenWithHttpMessagesAsync(value, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='model'>
            /// </param>
            public static IList<CursusInstantie> GetCursusInstantiesVanEenBepaaldeWeek(this ICursusInstantieService operations, DateModel model = default(DateModel))
            {
                return Task.Factory.StartNew(s => ((ICursusInstantieService)s).GetCursusInstantiesVanEenBepaaldeWeekAsync(model), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='model'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<CursusInstantie>> GetCursusInstantiesVanEenBepaaldeWeekAsync(this ICursusInstantieService operations, DateModel model = default(DateModel), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetCursusInstantiesVanEenBepaaldeWeekWithHttpMessagesAsync(model, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='values'>
            /// </param>
            public static object PostCursusInstanties(this ICursusInstantieService operations, IList<CursusInstantie> values = default(IList<CursusInstantie>))
            {
                return Task.Factory.StartNew(s => ((ICursusInstantieService)s).PostCursusInstantiesAsync(values), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='values'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> PostCursusInstantiesAsync(this ICursusInstantieService operations, IList<CursusInstantie> values = default(IList<CursusInstantie>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.PostCursusInstantiesWithHttpMessagesAsync(values, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static object GetByID(this ICursusInstantieService operations, int id)
            {
                return Task.Factory.StartNew(s => ((ICursusInstantieService)s).GetByIDAsync(id), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> GetByIDAsync(this ICursusInstantieService operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetByIDWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='inschrijving'>
            /// </param>
            public static object PostInschrijving(this ICursusInstantieService operations, Inschrijving inschrijving = default(Inschrijving))
            {
                return Task.Factory.StartNew(s => ((ICursusInstantieService)s).PostInschrijvingAsync(inschrijving), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='inschrijving'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> PostInschrijvingAsync(this ICursusInstantieService operations, Inschrijving inschrijving = default(Inschrijving), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.PostInschrijvingWithHttpMessagesAsync(inschrijving, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
