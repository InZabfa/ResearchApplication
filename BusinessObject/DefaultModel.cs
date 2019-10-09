namespace BusinessObject
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DefaultModel : DbContext
    {
        public DefaultModel()
            : base("name=DefaultModel")
        {
        }

        public virtual DbSet<AccessToken> AccessTokens { get; set; }
        public virtual DbSet<Difficulty> Difficulties { get; set; }
        public virtual DbSet<Experiment> Experiments { get; set; }
        public virtual DbSet<ExperimentInfo> ExperimentInfo { get; set; }
        public virtual DbSet<InteractiveResource> InteractiveResources { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<Researcher> Researchers { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<SessionLevel> SessionLevels { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Word> Words { get; set; }
        public virtual DbSet<WrongAnswer> WrongAnswers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Difficulty>()
                .HasMany(e => e.Words)
                .WithRequired(e => e.Difficulty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExperimentInfo>()
                .HasMany(e => e.Experiments)
                .WithRequired(e => e.ExperimentInfo)
                .HasForeignKey(e => e.ExperiemntInfoID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InteractiveResource>()
                .HasMany(e => e.Levels)
                .WithRequired(e => e.InteractiveResource)
                .HasForeignKey(e => e.ResourceID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InteractiveResource>()
                .HasMany(e => e.WrongAnswers)
                .WithRequired(e => e.InteractiveResource)
                .HasForeignKey(e => e.ResourceID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Level>()
                .HasMany(e => e.SessionLevels)
                .WithRequired(e => e.Level)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Level>()
                .HasMany(e => e.WrongAnswers)
                .WithRequired(e => e.Level)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Participant>()
                .HasMany(e => e.Experiments)
                .WithRequired(e => e.Participant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Researcher>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Researcher>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Researcher>()
                .Property(e => e.Deparment)
                .IsUnicode(false);

            modelBuilder.Entity<Researcher>()
                .HasMany(e => e.ExperimentInfoes)
                .WithRequired(e => e.Researcher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Researcher>()
                .HasMany(e => e.InteractiveResources)
                .WithRequired(e => e.Researcher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Session>()
                .HasMany(e => e.Experiments)
                .WithRequired(e => e.Session)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Session>()
                .HasMany(e => e.Logs)
                .WithRequired(e => e.Session)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SessionLevel>()
                .HasMany(e => e.Sessions)
                .WithRequired(e => e.SessionLevel)
                .HasForeignKey(e => e.SessionLevelsID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.AccessTokens)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Participants)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Researchers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Word>()
                .HasMany(e => e.InteractiveResources)
                .WithRequired(e => e.Word)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Word>()
                .HasMany(e => e.Levels)
                .WithRequired(e => e.Word)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Word>()
                .HasMany(e => e.WrongAnswers)
                .WithRequired(e => e.Word)
                .WillCascadeOnDelete(false);
        }
    }
}
