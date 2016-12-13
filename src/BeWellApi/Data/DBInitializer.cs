using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using BeWellApi.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BeWellApi.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any products.
                if (context.EmotionActivity.Any())
                {
                    return;   // DB has been seeded
                }

                var emotionCategories = new EmotionCategory[]
                {
                          new EmotionCategory {
                              Name = "Happiness"
                          },
                          new EmotionCategory {
                              Name = "Sadness"
                          },
                          new EmotionCategory {
                              Name = "Anger"
                          },
                          new EmotionCategory {
                              Name = "Contentment"
                          },
                          new EmotionCategory {
                              Name = "Fear"
                          }
                };

                foreach (EmotionCategory e in emotionCategories)
                {
                    context.EmotionCategory.Add(e);
                }
                context.SaveChanges();

                var emotions = new Emotion[]
                {
                         new Emotion {
                              Name = "Happy",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Happiness").EmotionCategoryId,
                              Value = 1
                          },
                         new Emotion {
                              Name = "Hopeful",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Happiness").EmotionCategoryId,
                              Value = 1
                          },
                           new Emotion {
                              Name = "Strong",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Happiness").EmotionCategoryId,
                              Value = 1
                          },
                          new Emotion {
                              Name = "Creative",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Happiness").EmotionCategoryId,
                              Value = 1
                          },
                           new Emotion {
                              Name = "Proud",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Happiness").EmotionCategoryId,
                              Value = 1
                          },
                           new Emotion {
                              Name = "Encouraged",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Happiness").EmotionCategoryId,
                              Value = 1
                          },
                          new Emotion {
                              Name = "Energetic",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Happiness").EmotionCategoryId,
                              Value = 1
                          },
                          new Emotion {
                              Name = "Optimistic",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Happiness").EmotionCategoryId,
                              Value = 1
                          },
                         new Emotion {
                              Name = "Content",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Contentment").EmotionCategoryId,
                              Value = 1
                          },
                           new Emotion {
                              Name = "Thankful",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Contentment").EmotionCategoryId,
                              Value = 1
                          },
                           new Emotion {
                              Name = "Loving",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Contentment").EmotionCategoryId,
                              Value = 1
                          },
                           new Emotion {
                              Name = "Balanced",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Contentment").EmotionCategoryId,
                              Value = 1
                          },
                          new Emotion {
                              Name = "Appreciative",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Contentment").EmotionCategoryId,
                              Value = 1
                          },
                           new Emotion {
                              Name = "Open-minded",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Contentment").EmotionCategoryId,
                              Value = 1
                          },
                           new Emotion {
                              Name = "Patient",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Contentment").EmotionCategoryId,
                              Value = 1
                          },
                            new Emotion {
                              Name = "Curious",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Contentment").EmotionCategoryId,
                              Value = 1
                          },
                           new Emotion {
                              Name = "Worried",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Fear").EmotionCategoryId,
                              Value = -1
                          },
                          new Emotion {
                              Name = "Unmotivated",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Fear").EmotionCategoryId,
                              Value =-1
                          },
                           new Emotion {
                              Name = "Stressed",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Fear").EmotionCategoryId,
                              Value = -1
                          },
                           new Emotion {
                              Name = "Anxious",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Fear").EmotionCategoryId,
                              Value = -1
                          },
                           new Emotion {
                              Name = "Restless",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Fear").EmotionCategoryId,
                              Value = -1
                          },
                          new Emotion {
                              Name = "Disconnected",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Fear").EmotionCategoryId,
                              Value = -1
                          },
                           new Emotion {
                              Name = "Conflicted",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Fear").EmotionCategoryId,
                              Value = -1
                          },
                           new Emotion {
                              Name = "Powerless",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Fear").EmotionCategoryId,
                              Value = -1
                          },
                          new Emotion {
                              Name = "Lonely",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Sadness").EmotionCategoryId,
                              Value = -1
                          },
                           new Emotion {
                              Name = "Sad",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Sadness").EmotionCategoryId,
                              Value = -1
                          },
                           new Emotion {
                              Name = "Hurt",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Sadness").EmotionCategoryId,
                              Value = -1
                          },
                           new Emotion {
                              Name = "Remorseful",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Sadness").EmotionCategoryId,
                              Value = -1
                          },
                          new Emotion {
                              Name = "Longing",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Sadness").EmotionCategoryId,
                              Value = -1
                          },
                           new Emotion {
                              Name = "Disappointed",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Sadness").EmotionCategoryId,
                              Value = -1
                          },
                           new Emotion {
                              Name = "Insecure",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Sadness").EmotionCategoryId,
                              Value = -1
                          },
                           new Emotion {
                              Name = "Fatigued",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Sadness").EmotionCategoryId,
                              Value = -1
                          },
                           new Emotion {
                              Name = "Angry",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Anger").EmotionCategoryId,
                              Value = -1
                          },
                           new Emotion {
                              Name = "Jealous",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Anger").EmotionCategoryId,
                              Value = -1
                          },
                          new Emotion {
                              Name = "Judgmental",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Anger").EmotionCategoryId,
                              Value = -1
                          },
                           new Emotion {
                              Name = "Pessimistic",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Anger").EmotionCategoryId,
                              Value = -1
                          },
                           new Emotion {
                              Name = "Resentful",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Anger").EmotionCategoryId,
                              Value = -1
                          },
                           new Emotion {
                              Name = "Self Critical",
                              EmotionCategoryId = emotionCategories.Single(s => s.Name == "Anger").EmotionCategoryId,
                              Value = -1
                          }
                };

                foreach (Emotion e in emotions)
                {
                    context.Emotion.Add(e);
                }
                context.SaveChanges();

                var activities = new Activity[]
                {
                          new Activity {
                              Name = "Gratitude Journal",
                              Description = "The benefits of practicing gratitude are nearly endless. People who regularly practice gratitude by taking time to notice and reflect upon the things they're thankful for experience more positive emotions, feel more alive, sleep better, express more compassion and kindness, and even have stronger immune systems. Reflect and think of all of the little things you are grateful for right now and write them down in a papar journal or the one provided in the app. ",
                              IsMeditation = false,
                              PhysicalMax = 2,
                              PhysicalMin = -2,
                              PointValue = 7,
                              UserAdded = false,
                              Minutes = null,
                              AWSUrl = null
                          },
                          new Activity {
                              Name = "Write a Letter",
                              Description = "You may want to write a letter to tell someone how much you love, appreciate, or are proud of them or you may want to write a letter to tell someone how upset and disappointed you are. Wherever your emotions are at today, take the time to think, write down how you feel and either send the letter or throw it away when you're done. You'll feel better either way.",
                              IsMeditation = false,
                              PhysicalMax = 2,
                              PhysicalMin = -2,
                              PointValue = 10,
                              UserAdded = false,
                              Minutes = null,
                              AWSUrl = null
                          },
                          new Activity {
                              Name = "Take a Walk",
                              Description = "Studies show that a brisk walk is just as effective as antidepressants in mild to moderate cases of depression, releasing feel-good endorphins while reducing stress and anxiety. So, for your mental health's sake, take a walk today.",
                              IsMeditation = false,
                              PhysicalMax = 2,
                              PhysicalMin = -1,
                              Minutes = null,
                              UserAdded = false,
                              PointValue = 6,
                              AWSUrl = null
                          },
                          new Activity {
                              Name = "Own the Story",
                              Description = "Sometimes when you’re in a bad mood, it’s tempting to cling to a story that justifies it, and then retell it over and over like a picture book you’ve heard a million times. And then he said this…And then I did this…And then I messed up… \n Visualize yourself closing a book and taking a new one off the shelf. Then start telling yourself a different story—one where you’re not a victim, one where you’re not powerless, one where you’re accepting what happened and moving on so you don’t lose anymore time to that other book. ",
                              IsMeditation = false,
                              PhysicalMax = 2,
                              PhysicalMin = -2,
                              PointValue = 2,
                              UserAdded = false,
                              Minutes = null,
                              AWSUrl = null
                          },
                         new Activity {
                              Name = "Turn on the Tunes",
                              Description = "Nothing’s better than going on a good drive and blasting your favorite tunes, maybe even getting into it a little bit with some head bobs and whatnot. A good tune can definitely lighten the mood, it’s science! Not to mention it can also help you lose weight. Wait, what?! Yeah, check that out.",
                              IsMeditation = false,
                              PhysicalMax = 2,
                              PhysicalMin = -2,
                              PointValue = 2,
                              UserAdded = false,
                              Minutes = null,
                              AWSUrl = null
                          },
                          new Activity {
                              Name = "Do Some Service",
                              Description = "Not trying to get sentimental here, but doing a good deed for someone else, no matter how I’m feeling, always gets me feeling a little fuzzy inside. Look for an opportunity to serve someone, no matter how small it may be.",
                              IsMeditation = false,
                              PhysicalMax = 2,
                              PhysicalMin = 0,
                              PointValue = 8,
                              UserAdded = false,
                              Minutes = null,
                              AWSUrl = null
                          },
                          new Activity {
                              Name = "Get in a Good Laugh",
                              Description = "I think we’ve probably all heard something like, “laughter is the best medicine,” and guess what? Getting in a good laugh can help you get out of a slump. Go ahead, flip on your favorite comedy, hang out with a friend, scroll through YouTube, or do whatever it is that makes you laugh.",
                              IsMeditation = false,
                              PhysicalMax = 2,
                              PhysicalMin = -2,
                              PointValue = 4,
                              UserAdded = false,
                              Minutes = null,
                              AWSUrl = null
                          },
                          new Activity {
                              Name = "Make Something Tangible",
                              Description = "Whether you are a painter, DIY crafter, furniture builder, or cook. Set aside some time today to put that skill to use. You don't have build something perfect, just let your creativity run free.",
                              IsMeditation = false,
                             PhysicalMax = 2,
                              PhysicalMin = -1,
                              PointValue = 15,
                              UserAdded = false,
                              Minutes = null,
                              AWSUrl = null
                          },
                           new Activity {
                              Name = "Write Something",
                              Description = "It doesn't matter if the words come out on paper or through an instrument, write something that releases your creativity or pain.",
                              IsMeditation = false,
                              PhysicalMax = 2,
                              PhysicalMin = -2,
                              PointValue = 12,
                              UserAdded = false,
                              Minutes = null,
                              AWSUrl = null
                          },
                           new Activity {
                              Name = "Make a List of Goals",
                              Description = "It is important to make a list of goals in a non-judgmental fashion. Think about your future and the things you want to accomplish or see in your life. Write them down and begin making a plan.",
                              IsMeditation = false,
                              PhysicalMax = 2,
                              PhysicalMin = -2,
                              PointValue = 7,
                              UserAdded = false,
                              Minutes = null,
                              AWSUrl = null
                          },
                           new Activity {
                              Name = "Read a Book",
                              Description = "Not only are books a great way to expand your knowledge, but when you read a book, all of your attention is focused on the story and the rest of the world just falls away. Books are a great way to unwind, focus and calm the thoughts going through your brain.",
                              IsMeditation = false,
                             PhysicalMax = 2,
                              PhysicalMin = -2,
                              PointValue = 7,
                              UserAdded = false,
                              Minutes = null,
                              AWSUrl = null
                          },
                           new Activity {
                              Name = "Do a Little Dance",
                              Description = "Whether you're having a crappy day or just found out the most exciting news, dancing can help improve or express your mood. Turn on your favorite dancing song and throw down some moves. No self-judgment of course!",
                              IsMeditation = false,
                              PhysicalMax = 2,
                              PhysicalMin = 0,
                              PointValue = 7,
                              UserAdded = false,
                              Minutes = null,
                              AWSUrl = null
                          },
                           new Activity {
                              Name = "Learn Something New",
                              Description = "Doing something entirely new gives you the chance to grow. You see, doing something for the first time, gives you the chance and space to improve tremendously. And throughout that wonderful experience you grow, you improve, and you update many areas of your life. \n Here is one analogy that can serve here – it’s recommended not to work out the same routine because the muscles become used to it, and they stop growing, or simply face diminished growth.",
                              IsMeditation = false,
                              PhysicalMax = 2,
                              PhysicalMin = -2,
                              PointValue = 15,
                              UserAdded = false,
                              Minutes = null,
                              AWSUrl = null
                          },
                          new Activity {
                              Name = "Tune into Your Breath",
                              Description = "Breathing is something that we all do, all of the time – yet we are often not aware of how it feels in the moment. By bringing our focus intentionally onto the breath we can ground ourselves in what is happening right now. We can practice observing without reacting, experiencing each breath as it happens without feeling a need to change it.",
                              IsMeditation = true,
                              PhysicalMax = 2,
                              PhysicalMin = -2,
                              PointValue = 7,
                              Minutes = 3,
                              UserAdded = false,
                              AWSUrl = "http://s3-us-east-2.amazonaws.com/bewellmeditations/Breathing3Min.mp3"
                          },
                          new Activity {
                              Name = "Body Scan",
                              Description = "Breathing is something that we all do, all of the time – yet we are often not aware of how it feels in the moment. By bringing our focus intentionally onto the breath we can ground ourselves in what is happening right now. We can practice observing without reacting, experiencing each breath as it happens without feeling a need to change it.",
                              IsMeditation = true,
                              PhysicalMax = 0,
                              PhysicalMin = -2,
                              PointValue = 9,
                              Minutes = 4,
                              UserAdded = false,
                              AWSUrl = "http://s3-us-east-2.amazonaws.com/bewellmeditations/4MinuteBodyScan.mp3"
                          },
                          new Activity {
                              Name = "Opening Our Hearts To Life as It Is",
                              Description = "This meditation awakens the senses with a mindful scanning of the body, establishes an anchor for presence, and invites us to arrive again and again, deepening the pathway home. When difficult or intense experience arises, the practice is to learn to open to what is here with a clear, allowing and kind attention.",
                              IsMeditation = true,
                              PhysicalMax = 2,
                              PhysicalMin = -2,
                              PointValue = 30,
                              Minutes = 20,
                              UserAdded = false,
                              AWSUrl = "http://s3-us-east-2.amazonaws.com/bewellmeditations/LifeAsItIs.mp3"
                          },
                           new Activity {
                              Name = "Deepening the Truths We Share",
                              Description = "Our capacity for love grows as we practice deepening the truths we share with each other. This short reflection offers guidance in how to bring your presence and heart to truth telling.",
                              IsMeditation = true,
                              PhysicalMax = 2,
                              PhysicalMin = -2,
                              PointValue = 15,
                              Minutes = 9,
                              UserAdded = false,
                              AWSUrl = "http://s3-us-east-2.amazonaws.com/bewellmeditations/DeepeningTruthsWeShare.mp3"
                          },
                            new Activity {
                              Name = "Loving Kindness Meditation",
                              Description = "The practice always begins with developing a loving acceptance of yourself. If resistance is experienced then it indicates that feelings of unworthiness are present. No matter, this means there is work to be done, as the practice itself is designed to overcome any feelings of self-doubt or negativity. Then you are ready to systematically develop loving-kindness towards others.",
                              IsMeditation = true,
                              PhysicalMax = 2,
                              PhysicalMin = -2,
                              PointValue = 15,
                              Minutes = 10,
                              UserAdded = false,
                              AWSUrl = "http://s3-us-east-2.amazonaws.com/bewellmeditations/LovingKindnessMeditation.mp3"
                          },
                            new Activity {
                              Name = "Meditation For Difficulty",
                              Description = "By practicing mindfulness, coming back to focus when the mind wanders, we are training in presence, irrespective of whether our experience is enjoyable. It’s normal to feel some discomfort while meditating—be it a physical pain, a difficult emotion, or an unpleasant thought. By gently returning attention to the breath or the whole body, we learn to manage these experiences wisely, consciously moving attention to a centered place of steady presence, rather than reacting automatically.",
                              IsMeditation = true,
                              PhysicalMax = 2,
                              PhysicalMin = -2,
                              PointValue = 12,
                              Minutes = 7,
                              UserAdded = false,
                              AWSUrl = "http://s3-us-east-2.amazonaws.com/bewellmeditations/MeditationForDifficulty.mp3"
                          },
                           new Activity {
                              Name = "Breath, Sound, Body",
                              Description = "The breath and the body are interconnected, as is seen from the fact that the breath is calm when the body is calm, and agitated or labored when the body is agitated or labored. The heavy exhalation made when feeling exhausted and the enthusiastic inhalation made when feeling energized or exhilarated establish the same fact.",
                              IsMeditation = true,
                              PhysicalMax = 2,
                              PhysicalMin = -2,
                              PointValue = 24,
                              Minutes = 12,
                              UserAdded = false,
                              AWSUrl = "http://s3-us-east-2.amazonaws.com/bewellmeditations/BreathSoundBody.mp3"
                          },
                           new Activity {
                              Name = "Meditation For Sleep",
                              Description = "Unwinding after a long, busy day isn’t easy, and curling up in bed with a smartphone or laptop won’t help. Start by shutting off all your blue-lit devices—minus the one playing this video, of course (no need to watch, just listen). Once you’ve literally disconnected, your mental activity will naturally begin to slow. Lie down under the covers, stretch your legs, and rest your palms on your stomach or by your head. Take three deep breaths. If your mind is wandering, it’s no big deal. Just take notice and return your thoughts to your breath, letting the inhale and exhale guide you into a calm, deeply relaxed state.",
                              IsMeditation = true,
                              PhysicalMax = 2,
                              PhysicalMin = -2,
                              PointValue = 28,
                              Minutes = 14,
                              UserAdded = false,
                              AWSUrl = "http://s3-us-east-2.amazonaws.com/bewellmeditations/BodyCanForSleep.mp3"
                          },
                          new Activity {
                              Name = "Listen To Your Breath",
                              Description = "Just by doing breathing meditation for ten or fifteen minutes each day, we will be able to reduce this stress. We will experience a calm, spacious feeling in the mind, and many of our usual problems will fall away. Difficult situations will become easier to deal with, we will naturally feel warm and well disposed towards other people, and our relationships with others will gradually improve.",
                              IsMeditation = true,
                              PhysicalMax = 2,
                              PhysicalMin = -2,
                              PointValue = 20,
                              Minutes = 9,
                              UserAdded = false,
                              AWSUrl = "http://s3-us-east-2.amazonaws.com/bewellmeditations/BreathingMeditation9Min.mp3"
                          }
                };

                foreach (Activity a in activities)
                {
                    context.Activity.Add(a);
                }
                context.SaveChanges();

                var emotionActivities = new EmotionActivity[]
                {
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Gratitude Journal").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Sad").EmotionId
                    },
                     new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Gratitude Journal").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Pessimistic").EmotionId
                    },
                     new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Gratitude Journal").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Insecure").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Gratitude Journal").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Resentful").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Gratitude Journal").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Jealous").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Gratitude Journal").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Self Critical").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Take a Walk").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Anxious").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Take a Walk").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Stressed").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Take a Walk").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Unmotivated").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Take a Walk").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Worried").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Take a Walk").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Restless").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Take a Walk").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Happy").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Take a Walk").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Hopeful").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Write a Letter").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Judgmental").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Write a Letter").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Hurt").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Write a Letter").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Disappointed").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Write a Letter").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Loving").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Write a Letter").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Appreciative").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Write a Letter").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Proud").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Write a Letter").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Thankful").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Write a Letter").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Creative").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Write a Letter").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Patient").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Write a Letter").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Angry").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Write a Letter").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Remorseful").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Own the Story").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Powerless").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Own the Story").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Resentful").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Own the Story").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Angry").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Own the Story").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Self Critical").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Own the Story").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Pessimistic").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Own the Story").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Disconnected").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Turn on the Tunes").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Angry").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Turn on the Tunes").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Anxious").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Turn on the Tunes").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Stressed").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Turn on the Tunes").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Sad").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Turn on the Tunes").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Worried").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Turn on the Tunes").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Self Critical").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Do Some Service").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Creative").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Do Some Service").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Restless").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Do Some Service").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Powerless").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Do Some Service").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Lonely").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Do Some Service").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Longing").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Do Some Service").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Loving").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Do Some Service").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Encouraged").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Do Some Service").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Energetic").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Get in a Good Laugh").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Pessimistic").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Get in a Good Laugh").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Disconnected").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Get in a Good Laugh").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Lonely").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Get in a Good Laugh").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Sad").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Get in a Good Laugh").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Hurt").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Get in a Good Laugh").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Insecure").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Get in a Good Laugh").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Fatigued").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Get in a Good Laugh").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Open-minded").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Learn Something New").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Curious").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Learn Something New").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Lonely").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Learn Something New").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Encouraged").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Learn Something New").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Hopeful").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Learn Something New").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Creative").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(e => e.Name == "Learn Something New").ActivityId,
                        EmotionId = emotions.Single(s => s.Name == "Restless").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Learn Something New").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Judgmental").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Make Something Tangible").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Creative").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Make Something Tangible").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Happy").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Make Something Tangible").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Energetic").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Make Something Tangible").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Open-minded").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Make Something Tangible").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Patient").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Make Something Tangible").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Curious").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Make Something Tangible").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Powerless").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Make Something Tangible").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Conflicted").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Write Something").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Creative").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Write Something").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Curious").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Write Something").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Balanced").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Write Something").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Hurt").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Write Something").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Angry").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Write Something").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Energetic").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Write Something").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Open-minded").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Make a List of Goals").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Pessimistic").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Make a List of Goals").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Optimistic").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Make a List of Goals").ActivityId,
                        EmotionId = emotions.Single(s => s.Name == "Unmotivated").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Make a List of Goals").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Disconnected").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Make a List of Goals").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Hopeful").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Make a List of Goals").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Energetic").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Make a List of Goals").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Encouraged").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Read a Book").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Restless").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Read a Book").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Happy").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Read a Book").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Sad").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Read a Book").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Pessimistic").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Read a Book").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Optimistic").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Read a Book").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Content").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Read a Book").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Balanced").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Read a Book").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Curious").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Do a Little Dance").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Encouraged").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Do a Little Dance").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Energetic").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Do a Little Dance").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Happy").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Do a Little Dance").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Longing").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Do a Little Dance").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Conflicted").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Do a Little Dance").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Creative").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Do a Little Dance").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Angry").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Do a Little Dance").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Hurt").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Do a Little Dance").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Disappointed").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Do a Little Dance").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Disconnected").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Body Scan").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Anxious").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Body Scan").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Stressed").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Body Scan").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Restless").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Body Scan").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Fatigued").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Opening Our Hearts To Life as It Is").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Resentful").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Opening Our Hearts To Life as It Is").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Disappointed").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Opening Our Hearts To Life as It Is").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Hurt").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Opening Our Hearts To Life as It Is").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Pessimistic").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Deepening the Truths We Share").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Happy").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Deepening the Truths We Share").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Optimistic").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Deepening the Truths We Share").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Strong").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Deepening the Truths We Share").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Thankful").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Deepening the Truths We Share").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Jealous").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Deepening the Truths We Share").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Conflicted").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Loving Kindness Meditation").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Angry").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Loving Kindness Meditation").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Hurt").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Loving Kindness Meditation").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Disappointed").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Loving Kindness Meditation").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Insecure").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Loving Kindness Meditation").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Curious").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Meditation For Difficulty").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Sad").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Meditation For Difficulty").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Unmotivated").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Meditation For Difficulty").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Conflicted").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Meditation For Difficulty").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Powerless").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Breath, Sound, Body").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Worried").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Breath, Sound, Body").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Disconnected").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Breath, Sound, Body").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Judgmental").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Breath, Sound, Body").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Self Critical").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Breath, Sound, Body").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Open-minded").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Breath, Sound, Body").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Patient").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Breath, Sound, Body").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Content").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Meditation For Sleep").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Fatigued").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Meditation For Sleep").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Restless").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Meditation For Sleep").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Stressed").EmotionId
                    },
                    new EmotionActivity {
                        ActivityId = activities.Single(s => s.Name == "Meditation For Sleep").ActivityId,
                        EmotionId = emotions.Single(e => e.Name == "Anxious").EmotionId
                    }
            };
                foreach (EmotionActivity e in emotionActivities)
                {
                    context.EmotionActivity.Add(e);
                }
                context.SaveChanges();
            }
        }
    }
}
