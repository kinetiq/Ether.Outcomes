using System;

namespace Ether.Outcomes.Composer
{
    public class OutcomeStep<T> : OutcomeResult<T>
    {

        //This is used for flow control. Else only fires if the previous expression
        //did not execute.
        private bool IsPreviousExpressionExecuted = false;

        //BreakIf is intended to stop execut
        private bool ShortCircuit = false;

        public OutcomeStep(IOutcome<T> outcome, bool previousExpressionExecuted) : base(outcome)
        {
            IsPreviousExpressionExecuted = previousExpressionExecuted;
        }

        /// <summary>
        /// Executes the specified expression.
        /// </summary>
        public OutcomeStep<T> Execute(Func<IOutcome<T>> expression)
        {
            if (ShortCircuit)
                return this;

            var outcome = expression(); //execute

            return new OutcomeStep<T>(outcome, true);
        }

        /// <summary>
        /// Executes the specified expression.
        /// </summary>
        public OutcomeStep<T> Execute(Func<IOutcome<T>, IOutcome<T>> expression)
        {
            if (ShortCircuit)
                return this;

            var outcome = expression(this); //execute

            return new OutcomeStep<T>(outcome, true);
        }

        /// <summary>
        /// If expression evaluates to true, the pipeline ends immediately,
        /// returning the current outcome and disregarding any remaining chained statements.
        /// </summary>
        public OutcomeStep<T> BreakIf(Func<IOutcome<T>, bool> expression)
        {
            if (ShortCircuit)
                return this;

            var result = expression(this); //execute

            if (!result)
                this.ShortCircuit = true;

            return this;
        }

        public OutcomeStep<T> If(Func<IOutcome<T>, bool> logicalExpression, Func<IOutcome<T>, IOutcome<T>> expression)
        {
            if (ShortCircuit)
                return this;

            if (!logicalExpression(this))
            {
                this.IsPreviousExpressionExecuted = false;
                return this;
            }

            return Execute(expression);
        }

        public OutcomeStep<T> If(Func<IOutcome<T>, bool> logicalExpression, Func<IOutcome<T>> expression)
        {
            if (ShortCircuit)
                return this;

            if (!logicalExpression(this))
            {
                this.IsPreviousExpressionExecuted = false;
                return this;
            }

            return Execute(expression);
        }

        /// <summary>
        /// Expression only executes if the previous expression failed.
        /// </summary>
        public OutcomeStep<T> IfFailure(Func<IOutcome<T>> expression)
        {
            if (ShortCircuit)
                return this;

            if (!this.Failure)
            {
                this.IsPreviousExpressionExecuted = false;
                return this;
            }

            var outcome = expression(); //execute

            return new OutcomeStep<T>(outcome, true);
        }

        /// <summary>
        /// Expression executes if the previous expression failed.
        /// </summary>
        public OutcomeStep<T> IfFailure(Func<IOutcome<T>, IOutcome<T>> expression)
        {
            if (ShortCircuit)
                return this;

            if (!this.Failure)
            {
                this.IsPreviousExpressionExecuted = false;
                return this;
            }

            var outcome = expression(this); //execute

            return new OutcomeStep<T>(outcome, true);
        }

        /// <summary>
        /// Expression executes if the previous statement was successful.
        /// </summary>
        public OutcomeStep<T> IfSuccess(Func<IOutcome<T>> expression)
        {        
            if (ShortCircuit)
                return this;

            if (!this.Success)
            {
                this.IsPreviousExpressionExecuted = false;
                return this;
            }

            var outcome = expression(); //execute

            return new OutcomeStep<T>(outcome, true);
        }

        /// <summary>
        /// Expression executes if the previous statement was successful.
        /// </summary>
        public OutcomeStep<T> IfSuccess(Func<IOutcome<T>, IOutcome<T>> expression)
        {
            if (ShortCircuit)
                return this;

            if (!this.Success)
            {
                this.IsPreviousExpressionExecuted = false;
                return this;
            }

            var outcome = expression(this); //execute

            return new OutcomeStep<T>(outcome, true);
        }

        /// <summary>
        /// Expression executes if the previous statement was logically skipped. For 
        /// instance, you could put this right after an IfSuccess() and it would 
        /// fire on failure.
        /// </summary>
        public OutcomeStep<T> Else(Func<IOutcome<T>> expression)
        {
            if (ShortCircuit)
                return this;

            if (this.IsPreviousExpressionExecuted)
            {
                this.IsPreviousExpressionExecuted = false;
                return this;
            }

            var outcome = expression(); //execute

            return new OutcomeStep<T>(outcome, true);
        }

        /// <summary>
        /// Expression executes if the previous statement did not execute.
        /// </summary>
        public OutcomeStep<T> Else(Func<IOutcome<T>, IOutcome<T>> expression)
        {
            if (ShortCircuit)
                return this;

            if (this.IsPreviousExpressionExecuted)
            {
                this.IsPreviousExpressionExecuted = false;
                return this;
            }

            var outcome = expression(this); //execute

            return new OutcomeStep<T>(outcome, true);
        }
    }
}
