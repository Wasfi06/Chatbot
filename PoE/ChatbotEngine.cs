using ChatbotGUI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberChatbotGUI
{
    public class ChatbotEngine
    {
        private string userName = "User";

        private string lastTopic = "";

        private string mood = "";

        private DatabaseAssist db = new DatabaseAssist();

        private List<string> activityLog =
            new List<string>();

        private Random random = new Random();

        private List<QuizQuestion> quizQuestions =
            new List<QuizQuestion>();

        private int currentQuestion = 0;

        private int score = 0;

        private bool quizMode = false;

        public ChatbotEngine()
        {
            LoadQuizQuestions();
        }

        public void SetUserName(string name)
        {
            userName = name;
        }

        public string GetResponse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "Please enter something.";

            input = input.ToLower();

            DetectSentiment(input);

            if (quizMode)
                return HandleQuiz(input);

            if (input.Contains("add task") ||
                input.Contains("remind me"))
            {
                TaskItem task = new TaskItem();

                task.Title = "Cybersecurity Task";
                task.Description = input;
                task.Reminder = "Tomorrow";
                task.Completed = false;

                db.AddTask(task);

                activityLog.Add(
                    $"Task added: {task.Description}");

                return "Task successfully added.";
            }

            if (input.Contains("show tasks"))
            {
                List<TaskItem> tasks =
                    db.GetTasks();

                if (tasks.Count == 0)
                    return "No tasks found.";

                string result = "";

                foreach (TaskItem t in tasks)
                {
                    result +=
                        $"ID: {t.Id}\n" +
                        $"Title: {t.Title}\n" +
                        $"Description: {t.Description}\n" +
                        $"Reminder: {t.Reminder}\n" +
                        $"Completed: {t.Completed}\n\n";
                }

                return result;
            }

            if (input.Contains("activity log") ||
                input.Contains("what have you done"))
            {
                if (activityLog.Count == 0)
                    return "No activity yet.";

                activityLog.Skip(Math.Max(0, activityLog.Count - 5));
            }

            if (input.Contains("start quiz"))
            {
                quizMode = true;

                currentQuestion = 0;

                score = 0;

                activityLog.Add("Quiz started.");

                return quizQuestions[currentQuestion].Question;
            }

            if (input.Contains("password"))
                lastTopic = "password";

            if (input.Contains("phishing"))
                lastTopic = "phishing";

            if (input.Contains("phishing"))
            {
                string[] responses =
                {
                    "Avoid suspicious links.",
                    "Verify email senders carefully.",
                    "Phishing scams imitate trusted companies."
                };

                return responses[random.Next(responses.Length)];
            }

            if (input.Contains("password"))
            {
                return
                    "Use strong passwords with numbers and symbols.";
            }

            if (input.Contains("tell me more"))
            {
                if (lastTopic == "password")
                {
                    return
                        "Avoid using the same password everywhere.";
                }

                if (lastTopic == "phishing")
                {
                    return
                        "Scammers often use fake websites.";
                }
            }

            if (mood == "worried")
            {
                return
                    "It's understandable to feel worried. Let me help you stay safe online.";
            }

            return
                "I didn’t quite understand that. Could you rephrase?";
        }

        private void DetectSentiment(string input)
        {
            if (input.Contains("worried") ||
                input.Contains("scared"))
            {
                mood = "worried";
            }

            else if (input.Contains("happy"))
            {
                mood = "happy";
            }
        }

        private void LoadQuizQuestions()
        {
            quizQuestions.Add(new QuizQuestion()
            {
                Question =
                    "True or False: Passwords should be shared.",
                Answer = "false",
                Explanation =
                    "Passwords should stay private."
            });

            quizQuestions.Add(new QuizQuestion()
            {
                Question =
                    "What attack tricks users into giving information?",
                Answer = "phishing",
                Explanation =
                    "Phishing tricks users into revealing information."
            });

            quizQuestions.Add(new QuizQuestion()
            {
                Question =
                    "True or False: HTTPS is safer.",
                Answer = "true",
                Explanation =
                    "HTTPS encrypts your connection."
            });

            quizQuestions.Add(new QuizQuestion()
            {
                Question =
                    "What improves account protection?",
                Answer = "2fa",
                Explanation =
                    "2FA adds another security layer."
            });

            quizQuestions.Add(new QuizQuestion()
            {
                Question =
                    "True or False: Clicking unknown links is safe.",
                Answer = "false",
                Explanation =
                    "Unknown links can contain malware."
            });

            quizQuestions.Add(new QuizQuestion()
            {
                Question =
                    "What software protects against malware?",
                Answer = "antivirus",
                Explanation =
                    "Antivirus software detects threats."
            });

            quizQuestions.Add(new QuizQuestion()
            {
                Question =
                    "True or False: Public WiFi is always safe.",
                Answer = "false",
                Explanation =
                    "Public WiFi may expose your data."
            });

            quizQuestions.Add(new QuizQuestion()
            {
                Question =
                    "What should strong passwords contain?",
                Answer = "symbols",
                Explanation =
                    "Strong passwords include symbols and numbers."
            });

            quizQuestions.Add(new QuizQuestion()
            {
                Question =
                    "True or False: Software updates improve security.",
                Answer = "true",
                Explanation =
                    "Updates patch vulnerabilities."
            });

            quizQuestions.Add(new QuizQuestion()
            {
                Question =
                    "What type of scam pretends to be legitimate?",
                Answer = "phishing",
                Explanation =
                    "Phishing pretends to be trustworthy."
            });
        }

        private string HandleQuiz(string input)
        {
            QuizQuestion q =
                quizQuestions[currentQuestion];

            string response;

            if (input.Contains(q.Answer))
            {
                score++;

                response =
                    "Correct! " + q.Explanation;
            }
            else
            {
                response =
                    "Incorrect. " + q.Explanation;
            }

            currentQuestion++;

            if (currentQuestion >= quizQuestions.Count)
            {
                quizMode = false;

                activityLog.Add(
                    $"Quiz completed. Score: {score}");

                return
                    response +
                    $"\nQuiz finished! Final Score: {score}/{quizQuestions.Count}";
            }

            return
                response +
                "\n\nNext Question:\n" +
                quizQuestions[currentQuestion].Question;
        }
    }
}