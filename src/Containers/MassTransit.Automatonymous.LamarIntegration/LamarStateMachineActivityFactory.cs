﻿namespace MassTransit.AutomatonymousLamarIntegration
{
    using Automatonymous;
    using GreenPipes;
    using Lamar;


    public class LamarStateMachineActivityFactory :
        IStateMachineActivityFactory
    {
        public Activity<TInstance, TData> GetActivity<TActivity, TInstance, TData>(BehaviorContext<TInstance, TData> context)
            where TActivity : Activity<TInstance, TData>
        {
            var lifetimeScope = context.GetPayload<IContainer>();

            return lifetimeScope.GetInstance<TActivity>();
        }

        public Activity<TInstance> GetActivity<TActivity, TInstance>(BehaviorContext<TInstance> context)
            where TActivity : Activity<TInstance>
        {
            var lifetimeScope = context.GetPayload<IContainer>();

            return lifetimeScope.GetInstance<TActivity>();
        }
    }
}
