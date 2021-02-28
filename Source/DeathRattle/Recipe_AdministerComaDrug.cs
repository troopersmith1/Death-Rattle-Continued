using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace DeathRattle
{
    public class Recipe_AdministerComaDrug : Recipe_Surgery
    {
        public override void ApplyOnPawn(Pawn pawn, BodyPartRecord part, Pawn billDoer, List<Thing> ingredients, Bill bill)
        {
            if (!pawn.RaceProps.IsFlesh)
            {
                return;
            }
            pawn.health.forceIncap = true;

            Hediff_Comatose ailment = HediffMaker.MakeHediff(HediffDefOfComatose.ArtificialComa, pawn) as Hediff_Comatose;
            pawn.health.AddHediff(ailment);

            pawn.health.forceIncap = false;
        }
        /*
        public override void ConsumeIngredient(Thing ingredient, RecipeDef recipe, Map map) {
        }
*/
        public override bool IsViolationOnPawn(Pawn pawn, BodyPartRecord part, Faction billDoerFaction)
        {
            if (pawn.Faction == billDoerFaction)
            {
                return false;
            }
            return true;
        }

    }
}
