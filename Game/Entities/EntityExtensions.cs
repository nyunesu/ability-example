using System;

namespace Entities
{
    public static class EntityExtensions
    {
        public static float CalculateDamage(this IEntity entity, float damage)
        {
            return damage;
        }

        public static TimeSpan CalculateDuration(this IEntity entity, float seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }

        public static TimeSpan CalculateInterval(this IEntity entity, float seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }

        public static float CalculateRadius(this IEntity entity, float radius)
        {
            return radius;
        }
    }
}