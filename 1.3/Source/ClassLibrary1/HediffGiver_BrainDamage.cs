using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using System.Threading.Tasks;

namespace DeathRattle
{
    public class HediffGiver_BrainDamage : HediffGiver
    {
        public float minSeverity;
        public float severityAmount;
        public float baseMtbDays;

        public override void OnIntervalPassed(Pawn pawn, Hediff cause)
        {
            if ((double)cause.Severity < (double)this.minSeverity || !Rand.MTBEventOccurs(this.baseMtbDays, 60000f, 60f))
                return;
            if (this.TryApply(pawn))
                this.SendLetter(pawn, cause);
            pawn.health.hediffSet.GetFirstHediffOfDef(this.hediff).Severity += this.severityAmount;
        }

    }

}
