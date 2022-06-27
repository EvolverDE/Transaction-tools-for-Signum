
Option Explicit On
Option Strict On

Imports TTS.ClsBase36


Public Class FrmTTS

    Private Sub BtPassPhrase_Click(sender As Object, e As EventArgs) Handles BtPassPhrase.Click

        Dim Masterkeys As List(Of String) = GetMasterKeys(TBPassPhrase.Text)
        TBPubKey.Text = Masterkeys(0)
        TBPubKey2.Text = Masterkeys(0)
        TBSigKey.Text = Masterkeys(1)
        TBSigKey2.Text = Masterkeys(1)
        TBAgreeKey.Text = Masterkeys(2)

        Dim AccID As ULong = GetAccountID(TBPubKey.Text)
        TBAccID.Text = AccID.ToString

        Dim AccRS As String = GetAccountRS(TBPubKey.Text)
        TBAccRS.Text = "S-" + AccRS + "-" + EncodeHexToBase36(TBPubKey.Text)

        If TBPassPhrase.Text.Trim.Length = 0 Then
            ClsMsgs.MBox("the PassPhrase is empty." + vbCrLf + "it should be as long as possible!", "empty PassPhrase",,, ClsMsgs.Status.Attention)
        ElseIf TBPassPhrase.Text.Trim.Length < 32 Then
            ClsMsgs.MBox("the PassPhrase is really short." + vbCrLf + " it should be as long as possible!", "short PassPhrase",,, ClsMsgs.Status.Warning)
        End If

    End Sub

    Private Sub BtPubKey_Click(sender As Object, e As EventArgs) Handles BtPubKey.Click

        If TBPubKey.Text.Trim.Length >= 32 Then
            If MessageIsHEXString(TBPubKey.Text) Then

                Dim AccID As ULong = GetAccountID(TBPubKey.Text)
                TBAccID.Text = AccID.ToString

                Dim AccRS As String = GetAccountRS(TBPubKey.Text)
                TBAccRS.Text = "S-" + AccRS + "-" + EncodeHexToBase36(TBPubKey.Text)


            Else
                ClsMsgs.MBox("the input is not just HEX", "error",,, ClsMsgs.Status.Erro)
                TBAccID.Text = ""
                TBAccRS.Text = ""

            End If

        Else
            ClsMsgs.MBox("the input is not long enough", "error",,, ClsMsgs.Status.Erro)
            TBAccID.Text = ""
            TBAccRS.Text = ""

        End If

        TBPassPhrase.Text = ""
        TBSigKey.Text = ""
        TBSigKey2.Text = ""
        TBAgreeKey.Text = ""

    End Sub

    Private Sub BtAccID_Click(sender As Object, e As EventArgs) Handles BtAccID.Click

        If IsNumber(TBAccID.Text) Then
            Dim AccRS As String = ""
            Try
                AccRS = GetAccountRSFromID(CULng(TBAccID.Text.Trim))
            Catch ex As Exception
                ClsMsgs.MBox("the input can't be converted", "error",,, ClsMsgs.Status.Erro)
                TBAccRS.Text = ""
            End Try

            TBAccRS.Text = "S-" + AccRS
        Else
            ClsMsgs.MBox("the input is not just numeric", "error",,, ClsMsgs.Status.Erro)
            TBAccRS.Text = ""
        End If

        TBPassPhrase.Text = ""
        TBPubKey.Text = ""
        TBPubKey2.Text = ""
        TBSigKey.Text = ""
        TBSigKey2.Text = ""
        TBAgreeKey.Text = ""

    End Sub

    Private Sub BtRS_Click(sender As Object, e As EventArgs) Handles BtRS.Click

        Dim Address As String = TBAccRS.Text.Trim
        Dim AddressList As List(Of String) = CutAddress(Address)

        If AddressList.Count = 0 Then
            ClsMsgs.MBox("the input is not ReedSolomon", "error",,, ClsMsgs.Status.Erro)
            TBAccID.Text = ""
            TBPubKey.Text = ""
            TBPubKey2.Text = ""
        ElseIf AddressList.Count = 1 Then
            TBAccID.Text = AddressList(0)
        Else
            TBAccID.Text = AddressList(0)
            TBPubKey.Text = AddressList(1)
            TBPubKey2.Text = AddressList(1)
        End If


        TBPassPhrase.Text = ""
        TBSigKey.Text = ""
        TBSigKey2.Text = ""
        TBAgreeKey.Text = ""

    End Sub


    Function CutAddress(ByVal Address As String) As List(Of String)

        Dim ReturnList As List(Of String) = New List(Of String)

        If Address.Trim = "" Then
            Return ReturnList
        End If

        Dim PreFix As String = ""

        If Address.Contains("-") Then
            PreFix = Address.Remove(Address.IndexOf("-") + 1)
        Else
            Return ReturnList
        End If


        If PreFix.Contains("S-") Then 'TODO: Change TS-Tag
            Address = Address.Substring(Address.IndexOf(PreFix) + PreFix.Length)
        End If

        Select Case CharCnt(Address, "-")
            Case 3

                If IsReedSolomon(Address) Then
                    Dim AccID As ULong = GetAccountIDFromRS(Address)
                    ReturnList.Add(AccID.ToString)
                End If

            Case 4

                Dim PubKeyBase36 As String = Address.Substring(Address.LastIndexOf("-") + 1)
                Address = Address.Remove(Address.IndexOf(PubKeyBase36) - 1)

                If IsReedSolomon(Address) Then
                    Dim AccID As ULong = GetAccountIDFromRS(Address)
                    ReturnList.Add(AccID.ToString)

                    Dim PubKeyHex As String = DecodeBase36ToHex(PubKeyBase36)
                    ReturnList.Add(PubKeyHex)
                End If

        End Select

        Return ReturnList

    End Function



    Dim WordCNT As Integer = 1626
    Dim Words As String() = {"like", "just", "love", "know", "never", "want", "time", "out", "there", "make", "look", "eye", "down", "only", "think", "heart", "back", "then", "into", "about", "more", "away", "still", "them", "take", "thing", "even", "through", "long", "always", "world", "too", "friend", "tell", "try", "hand", "thought", "over", "here", "other", "need", "smile", "again", "much", "cry", "been", "night", "ever", "little", "said", "end", "some", "those", "around", "mind", "people", "girl", "leave", "dream", "left", "turn", "myself", "give", "nothing", "really", "off", "before", "something", "find", "walk", "wish", "good", "once", "place", "ask", "stop", "keep", "watch", "seem", "everything", "wait", "got", "yet", "made", "remember", "start", "alone", "run", "hope", "maybe", "believe", "body", "hate", "after", "close", "talk", "stand", "own", "each", "hurt", "help", "home", "god", "soul", "new", "many", "two", "inside", "should", "true", "first", "fear", "mean", "better", "play", "another", "gone", "change", "use", "wonder", "someone", "hair", "cold", "open", "best", "any", "behind", "happen", "water", "dark", "laugh", "stay", "forever", "name", "work", "show", "sky", "break", "came", "deep", "door", "put", "black", "together", "upon", "happy", "such", "great", "white", "matter", "fill", "past", "please", "burn", "cause", "enough", "touch", "moment", "soon", "voice", "scream", "anything", "stare", "sound", "red", "everyone", "hide", "kiss", "truth", "death", "beautiful", "mine", "blood", "broken", "very", "pass", "next", "forget", "tree", "wrong", "air", "mother", "understand", "lip", "hit", "wall", "memory", "sleep", "free", "high", "realize", "school", "might", "skin", "sweet", "perfect", "blue", "kill", "breath", "dance", "against", "fly", "between", "grow", "strong", "under", "listen", "bring", "sometimes", "speak", "pull", "person", "become", "family", "begin", "ground", "real", "small", "father", "sure", "feet", "rest", "young", "finally", "land", "across", "today", "different", "guy", "line", "fire", "reason", "reach", "second", "slowly", "write", "eat", "smell", "mouth", "step", "learn", "three", "floor", "promise", "breathe", "darkness", "push", "earth", "guess", "save", "song", "above", "along", "both", "color", "house", "almost", "sorry", "anymore", "brother", "okay", "dear", "game", "fade", "already", "apart", "warm", "beauty", "heard", "notice", "question", "shine", "began", "piece", "whole", "shadow", "secret", "street", "within", "finger", "point", "morning", "whisper", "child", "moon", "green", "story", "glass", "kid", "silence", "since", "soft", "yourself", "empty", "shall", "angel", "answer", "baby", "bright", "dad", "path", "worry", "hour", "drop", "follow", "power", "war", "half", "flow", "heaven", "act", "chance", "fact", "least", "tired", "children", "near", "quite", "afraid", "rise", "sea", "taste", "window", "cover", "nice", "trust", "lot", "sad", "cool", "force", "peace", "return", "blind", "easy", "ready", "roll", "rose", "drive", "held", "music", "beneath", "hang", "mom", "paint", "emotion", "quiet", "clear", "cloud", "few", "pretty", "bird", "outside", "paper", "picture", "front", "rock", "simple", "anyone", "meant", "reality", "road", "sense", "waste", "bit", "leaf", "thank", "happiness", "meet", "men", "smoke", "truly", "decide", "self", "age", "book", "form", "alive", "carry", "escape", "damn", "instead", "able", "ice", "minute", "throw", "catch", "leg", "ring", "course", "goodbye", "lead", "poem", "sick", "corner", "desire", "known", "problem", "remind", "shoulder", "suppose", "toward", "wave", "drink", "jump", "woman", "pretend", "sister", "week", "human", "joy", "crack", "grey", "pray", "surprise", "dry", "knee", "less", "search", "bleed", "caught", "clean", "embrace", "future", "king", "son", "sorrow", "chest", "hug", "remain", "sat", "worth", "blow", "daddy", "final", "parent", "tight", "also", "create", "lonely", "safe", "cross", "dress", "evil", "silent", "bone", "fate", "perhaps", "anger", "class", "scar", "snow", "tiny", "tonight", "continue", "control", "dog", "edge", "mirror", "month", "suddenly", "comfort", "given", "loud", "quickly", "gaze", "plan", "rush", "stone", "town", "battle", "ignore", "spirit", "stood", "stupid", "yours", "brown", "build", "dust", "hey", "kept", "pay", "phone", "twist", "although", "ball", "beyond", "hidden", "nose", "taken", "fail", "float", "pure", "somehow", "wash", "wrap", "angry", "cheek", "creature", "forgotten", "heat", "rip", "single", "space", "special", "weak", "whatever", "yell", "anyway", "blame", "job", "choose", "country", "curse", "drift", "echo", "figure", "grew", "laughter", "neck", "suffer", "worse", "yeah", "disappear", "foot", "forward", "knife", "mess", "somewhere", "stomach", "storm", "beg", "idea", "lift", "offer", "breeze", "field", "five", "often", "simply", "stuck", "win", "allow", "confuse", "enjoy", "except", "flower", "seek", "strength", "calm", "grin", "gun", "heavy", "hill", "large", "ocean", "shoe", "sigh", "straight", "summer", "tongue", "accept", "crazy", "everyday", "exist", "grass", "mistake", "sent", "shut", "surround", "table", "ache", "brain", "destroy", "heal", "nature", "shout", "sign", "stain", "choice", "doubt", "glance", "glow", "mountain", "queen", "stranger", "throat", "tomorrow", "city", "either", "fish", "flame", "rather", "shape", "spin", "spread", "ash", "distance", "finish", "image", "imagine", "important", "nobody", "shatter", "warmth", "became", "feed", "flesh", "funny", "lust", "shirt", "trouble", "yellow", "attention", "bare", "bite", "money", "protect", "amaze", "appear", "born", "choke", "completely", "daughter", "fresh", "friendship", "gentle", "probably", "six", "deserve", "expect", "grab", "middle", "nightmare", "river", "thousand", "weight", "worst", "wound", "barely", "bottle", "cream", "regret", "relationship", "stick", "test", "crush", "endless", "fault", "itself", "rule", "spill", "art", "circle", "join", "kick", "mask", "master", "passion", "quick", "raise", "smooth", "unless", "wander", "actually", "broke", "chair", "deal", "favorite", "gift", "note", "number", "sweat", "box", "chill", "clothes", "lady", "mark", "park", "poor", "sadness", "tie", "animal", "belong", "brush", "consume", "dawn", "forest", "innocent", "pen", "pride", "stream", "thick", "clay", "complete", "count", "draw", "faith", "press", "silver", "struggle", "surface", "taught", "teach", "wet", "bless", "chase", "climb", "enter", "letter", "melt", "metal", "movie", "stretch", "swing", "vision", "wife", "beside", "crash", "forgot", "guide", "haunt", "joke", "knock", "plant", "pour", "prove", "reveal", "steal", "stuff", "trip", "wood", "wrist", "bother", "bottom", "crawl", "crowd", "fix", "forgive", "frown", "grace", "loose", "lucky", "party", "release", "surely", "survive", "teacher", "gently", "grip", "speed", "suicide", "travel", "treat", "vein", "written", "cage", "chain", "conversation", "date", "enemy", "however", "interest", "million", "page", "pink", "proud", "sway", "themselves", "winter", "church", "cruel", "cup", "demon", "experience", "freedom", "pair", "pop", "purpose", "respect", "shoot", "softly", "state", "strange", "bar", "birth", "curl", "dirt", "excuse", "lord", "lovely", "monster", "order", "pack", "pants", "pool", "scene", "seven", "shame", "slide", "ugly", "among", "blade", "blonde", "closet", "creek", "deny", "drug", "eternity", "gain", "grade", "handle", "key", "linger", "pale", "prepare", "swallow", "swim", "tremble", "wheel", "won", "cast", "cigarette", "claim", "college", "direction", "dirty", "gather", "ghost", "hundred", "loss", "lung", "orange", "present", "swear", "swirl", "twice", "wild", "bitter", "blanket", "doctor", "everywhere", "flash", "grown", "knowledge", "numb", "pressure", "radio", "repeat", "ruin", "spend", "unknown", "buy", "clock", "devil", "early", "false", "fantasy", "pound", "precious", "refuse", "sheet", "teeth", "welcome", "add", "ahead", "block", "bury", "caress", "content", "depth", "despite", "distant", "marry", "purple", "threw", "whenever", "bomb", "dull", "easily", "grasp", "hospital", "innocence", "normal", "receive", "reply", "rhyme", "shade", "someday", "sword", "toe", "visit", "asleep", "bought", "center", "consider", "flat", "hero", "history", "ink", "insane", "muscle", "mystery", "pocket", "reflection", "shove", "silently", "smart", "soldier", "spot", "stress", "train", "type", "view", "whether", "bus", "energy", "explain", "holy", "hunger", "inch", "magic", "mix", "noise", "nowhere", "prayer", "presence", "shock", "snap", "spider", "study", "thunder", "trail", "admit", "agree", "bag", "bang", "bound", "butterfly", "cute", "exactly", "explode", "familiar", "fold", "further", "pierce", "reflect", "scent", "selfish", "sharp", "sink", "spring", "stumble", "universe", "weep", "women", "wonderful", "action", "ancient", "attempt", "avoid", "birthday", "branch", "chocolate", "core", "depress", "drunk", "especially", "focus", "fruit", "honest", "match", "palm", "perfectly", "pillow", "pity", "poison", "roar", "shift", "slightly", "thump", "truck", "tune", "twenty", "unable", "wipe", "wrote", "coat", "constant", "dinner", "drove", "egg", "eternal", "flight", "flood", "frame", "freak", "gasp", "glad", "hollow", "motion", "peer", "plastic", "root", "screen", "season", "sting", "strike", "team", "unlike", "victim", "volume", "warn", "weird", "attack", "await", "awake", "built", "charm", "crave", "despair", "fought", "grant", "grief", "horse", "limit", "message", "ripple", "sanity", "scatter", "serve", "split", "string", "trick", "annoy", "blur", "boat", "brave", "clearly", "cling", "connect", "fist", "forth", "imagination", "iron", "jock", "judge", "lesson", "milk", "misery", "nail", "naked", "ourselves", "poet", "possible", "princess", "sail", "size", "snake", "society", "stroke", "torture", "toss", "trace", "wise", "bloom", "bullet", "cell", "check", "cost", "darling", "during", "footstep", "fragile", "hallway", "hardly", "horizon", "invisible", "journey", "midnight", "mud", "nod", "pause", "relax", "shiver", "sudden", "value", "youth", "abuse", "admire", "blink", "breast", "bruise", "constantly", "couple", "creep", "curve", "difference", "dumb", "emptiness", "gotta", "honor", "plain", "planet", "recall", "rub", "ship", "slam", "soar", "somebody", "tightly", "weather", "adore", "approach", "bond", "bread", "burst", "candle", "coffee", "cousin", "crime", "desert", "flutter", "frozen", "grand", "heel", "hello", "language", "level", "movement", "pleasure", "powerful", "random", "rhythm", "settle", "silly", "slap", "sort", "spoken", "steel", "threaten", "tumble", "upset", "aside", "awkward", "bee", "blank", "board", "button", "card", "carefully", "complain", "crap", "deeply", "discover", "drag", "dread", "effort", "entire", "fairy", "giant", "gotten", "greet", "illusion", "jeans", "leap", "liquid", "march", "mend", "nervous", "nine", "replace", "rope", "spine", "stole", "terror", "accident", "apple", "balance", "boom", "childhood", "collect", "demand", "depression", "eventually", "faint", "glare", "goal", "group", "honey", "kitchen", "laid", "limb", "machine", "mere", "mold", "murder", "nerve", "painful", "poetry", "prince", "rabbit", "shelter", "shore", "shower", "soothe", "stair", "steady", "sunlight", "tangle", "tease", "treasure", "uncle", "begun", "bliss", "canvas", "cheer", "claw", "clutch", "commit", "crimson", "crystal", "delight", "doll", "existence", "express", "fog", "football", "gay", "goose", "guard", "hatred", "illuminate", "mass", "math", "mourn", "rich", "rough", "skip", "stir", "student", "style", "support", "thorn", "tough", "yard", "yearn", "yesterday", "advice", "appreciate", "autumn", "bank", "beam", "bowl", "capture", "carve", "collapse", "confusion", "creation", "dove", "feather", "girlfriend", "glory", "government", "harsh", "hop", "inner", "loser", "moonlight", "neighbor", "neither", "peach", "pig", "praise", "screw", "shield", "shimmer", "sneak", "stab", "subject", "throughout", "thrown", "tower", "twirl", "wow", "army", "arrive", "bathroom", "bump", "cease", "cookie", "couch", "courage", "dim", "guilt", "howl", "hum", "husband", "insult", "led", "lunch", "mock", "mostly", "natural", "nearly", "needle", "nerd", "peaceful", "perfection", "pile", "price", "remove", "roam", "sanctuary", "serious", "shiny", "shook", "sob", "stolen", "tap", "vain", "void", "warrior", "wrinkle", "affection", "apologize", "blossom", "bounce", "bridge", "cheap", "crumble", "decision", "descend", "desperately", "dig", "dot", "flip", "frighten", "heartbeat", "huge", "lazy", "lick", "odd", "opinion", "process", "puzzle", "quietly", "retreat", "score", "sentence", "separate", "situation", "skill", "soak", "square", "stray", "taint", "task", "tide", "underneath", "veil", "whistle", "anywhere", "bedroom", "bid", "bloody", "burden", "careful", "compare", "concern", "curtain", "decay", "defeat", "describe", "double", "dreamer", "driver", "dwell", "evening", "flare", "flicker", "grandma", "guitar", "harm", "horrible", "hungry", "indeed", "lace", "melody", "monkey", "nation", "object", "obviously", "rainbow", "salt", "scratch", "shown", "shy", "stage", "stun", "third", "tickle", "useless", "weakness", "worship", "worthless", "afternoon", "beard", "boyfriend", "bubble", "busy", "certain", "chin", "concrete", "desk", "diamond", "doom", "drawn", "due", "felicity", "freeze", "frost", "garden", "glide", "harmony", "hopefully", "hunt", "jealous", "lightning", "mama", "mercy", "peel", "physical", "position", "pulse", "punch", "quit", "rant", "respond", "salty", "sane", "satisfy", "savior", "sheep", "slept", "social", "sport", "tuck", "utter", "valley", "wolf", "aim", "alas", "alter", "arrow", "awaken", "beaten", "belief", "brand", "ceiling", "cheese", "clue", "confidence", "connection", "daily", "disguise", "eager", "erase", "essence", "everytime", "expression", "fan", "flag", "flirt", "foul", "fur", "giggle", "glorious", "ignorance", "law", "lifeless", "measure", "mighty", "muse", "north", "opposite", "paradise", "patience", "patient", "pencil", "petal", "plate", "ponder", "possibly", "practice", "slice", "spell", "stock", "strife", "strip", "suffocate", "suit", "tender", "tool", "trade", "velvet", "verse", "waist", "witch", "aunt", "bench", "bold", "cap", "certainly", "click", "companion", "creator", "dart", "delicate", "determine", "dish", "dragon", "drama", "drum", "dude", "everybody", "feast", "forehead", "former", "fright", "fully", "gas", "hook", "hurl", "invite", "juice", "manage", "moral", "possess", "raw", "rebel", "royal", "scale", "scary", "several", "slight", "stubborn", "swell", "talent", "tea", "terrible", "thread", "torment", "trickle", "usually", "vast", "violence", "weave", "acid", "agony", "ashamed", "awe", "belly", "blend", "blush", "character", "cheat", "common", "company", "coward", "creak", "danger", "deadly", "defense", "define", "depend", "desperate", "destination", "dew", "duck", "dusty", "embarrass", "engine", "example", "explore", "foe", "freely", "frustrate", "generation", "glove", "guilty", "health", "hurry", "idiot", "impossible", "inhale", "jaw", "kingdom", "mention", "mist", "moan", "mumble", "mutter", "observe", "ode", "pathetic", "pattern", "pie", "prefer", "puff", "rape", "rare", "revenge", "rude", "scrape", "spiral", "squeeze", "strain", "sunset", "suspend", "sympathy", "thigh", "throne", "total", "unseen", "weapon", "weary"}


    Function GetPass(ByVal FlipFlop As Integer, Optional ByVal Length As Integer = 12, Optional ByVal Salt As Integer = 0) As String

        Dim T_Pass As String = ""
        Dim RandNum As New Random

        For i As Integer = 0 To Length - 1

            Dim RandomInt As Integer = 0

            RandomInt += Salt

            If RandomInt > WordCNT Then
                RandomInt = RandomInt Mod WordCNT
            ElseIf RandomInt = WordCNT Then
                RandomInt -= 1
            End If

            If FlipFlop = 0 Then
                RandomInt = RandNum.Next(0, WordCNT)
                T_Pass += Words(RandomInt) + " "
            Else
                RandomInt = RandNum.Next(1, 62)
                T_Pass += GenRandomChar(RandomInt)
            End If

        Next

        Return T_Pass.Trim

    End Function

    Function GenRandomChar(ByVal Rand As Integer) As String

        Select Case Rand
            Case 1
                Return "0"
            Case 2
                Return "1"
            Case 3
                Return "2"
            Case 4
                Return "3"
            Case 5
                Return "4"
            Case 6
                Return "5"
            Case 7
                Return "6"
            Case 8
                Return "7"
            Case 9
                Return "8"
            Case 10
                Return "9"

            Case 11
                Return "A"
            Case 12
                Return "B"
            Case 13
                Return "C"
            Case 14
                Return "D"
            Case 15
                Return "E"
            Case 16
                Return "F"
            Case 17
                Return "G"
            Case 18
                Return "H"
            Case 19
                Return "I"
            Case 20
                Return "J"
            Case 21
                Return "K"
            Case 22
                Return "L"
            Case 23
                Return "M"
            Case 24
                Return "N"
            Case 25
                Return "O"
            Case 26
                Return "P"
            Case 27
                Return "Q"
            Case 28
                Return "R"
            Case 29
                Return "S"
            Case 30
                Return "T"
            Case 31
                Return "U"
            Case 32
                Return "V"
            Case 33
                Return "W"
            Case 34
                Return "X"
            Case 35
                Return "Y"
            Case 36
                Return "Z"


            Case 37
                Return "a"
            Case 38
                Return "b"
            Case 39
                Return "c"
            Case 40
                Return "d"
            Case 41
                Return "e"
            Case 42
                Return "f"
            Case 43
                Return "g"
            Case 44
                Return "h"
            Case 45
                Return "i"
            Case 46
                Return "j"
            Case 47
                Return "k"
            Case 48
                Return "l"
            Case 49
                Return "m"
            Case 50
                Return "n"
            Case 51
                Return "o"
            Case 52
                Return "p"
            Case 53
                Return "q"
            Case 54
                Return "r"
            Case 55
                Return "s"
            Case 56
                Return "t"
            Case 57
                Return "u"
            Case 58
                Return "v"
            Case 59
                Return "w"
            Case 60
                Return "x"
            Case 61
                Return "y"
            Case 62
                Return "z"

        End Select

        Return ""

    End Function


    Private Sub BtNew_Click(sender As Object, e As EventArgs) Handles BtNew.Click

        Dim RandNum As New Random
        Dim Pass As String = ""

        If RBtWords.Checked Then
            Pass = GetPass(0, CInt(NUDWordsChars.Value), RandNum.Next(0, CInt(NUDWordsChars.Value)))
        Else
            Pass = GetPass(1, CInt(NUDWordsChars.Value), RandNum.Next(0, CInt(NUDWordsChars.Value)))
        End If

        TBPassPhrase.Text = Pass
        BtPassPhrase.PerformClick()

    End Sub

    Private Sub BtSign_Click(sender As Object, e As EventArgs) Handles BtSign.Click

        TBTXBytes.Text = ""

        If Not TBSigKey.Text.Trim = "" And Not TBUTXBytes.Text.Trim = "" Then
            If TBUTXBytes.Text.Length > 320 Then
                If MessageIsHEXString(TBUTXBytes.Text) Then

                    If TBUTXBytes.Text.Contains(TBPubKey2.Text) Then
                        TBTXBytes.Text = SignHelper(TBUTXBytes.Text, TBSigKey2.Text).SignedTransaction
                    Else
                        MsgBox("PublicKey don't match Unsigned TransactionBytes",, "Error")
                    End If

                Else
                    MsgBox("Unsigned TransactionBytes is no HEX-String",, "Error")
                End If

            Else
                MsgBox("Unsigned TransactionBytes is not long enough",, "Error")
            End If

        Else
            MsgBox("Unsigned TransactionBytes or SignatureKey is nothing",, "Error")
        End If

    End Sub

    Function MessageIsHEXString(ByVal Message As String) As Boolean

        If Message.Length Mod 2 <> 0 Then
            Return False
        End If

        Dim CharAry() As Char = Message.ToUpper.ToCharArray

        For Each Chr As Char In CharAry
            Select Case Chr
                Case "0"c, "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c, "A"c, "B"c, "C"c, "D"c, "E"c, "F"c
                Case Else
                    Return False
            End Select

        Next

        Return True

    End Function

    Public Structure S_Signature
        Dim AgreementKey As String
        Dim SignatureKey As String
        Dim PublicKey As String

        Dim UnsignedTransaction As String
        Dim SignedTransaction As String
        Dim SignatureHash As String
        Dim Sign As String
        Dim FullHash As String

    End Structure

    Function SignHelper(ByVal UnsignedMessageHex As String, ByVal SignKeyHEX As String) As S_Signature

        Dim Signature As S_Signature = New S_Signature

        Dim Sign As String = GenerateSignature(UnsignedMessageHex, SignKeyHEX)

        Signature.Sign = Sign

        Dim TransactionHEX As String = UnsignedMessageHex

        Dim TXBEnd As String = TransactionHEX.Substring(320)
        TransactionHEX = TransactionHEX.Remove(192)
        TransactionHEX &= Sign & TXBEnd
        Signature.SignedTransaction = TransactionHEX

        Dim cSHA256_sigHash As System.Security.Cryptography.SHA256 = System.Security.Cryptography.SHA256Managed.Create()
        Dim signatureHash As Byte() = cSHA256_sigHash.ComputeHash(HEXStringToByteArray(Sign))
        Signature.SignatureHash = ByteArrayToHEXString(signatureHash)

        Signature.FullHash = CalculateFullHash(UnsignedMessageHex, Signature.SignatureHash)

        Return Signature

    End Function

    Function CalculateFullHash(ByVal UnsignedMessageHex As String, ByVal SignHash As String) As String

        Dim SHA256 As System.Security.Cryptography.SHA256 = System.Security.Cryptography.SHA256.Create()
        Dim temp1 As Byte() = HEXStringToByteArray(UnsignedMessageHex)
        Dim temp2 As Byte() = HEXStringToByteArray(SignHash)
        Dim temp3 As Byte() = SHA256.ComputeHash(temp1.Concat(temp2).ToArray)

        Dim ret As String = ByteArrayToHEXString(temp3)
        Return ret

    End Function

    Private Sub TBPassPhrase_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBPassPhrase.KeyPress

        Dim keys As Integer = Asc(e.KeyChar)

        Select Case keys
                'Case 48 To 57, 44, 8
                    ' numbers, 8=Backspace and 32=Space 46=Punkt 44=Komma are ok
            Case 13
                ' ENTER
                BtPassPhrase.PerformClick()
                e.Handled = True
            Case Else
                'all other inputs
                'e.Handled = True
        End Select

    End Sub

    Private Sub BtShowHidePass_Click(sender As Object, e As EventArgs) Handles BtShowHidePass.Click

        If TBPassPhrase.UseSystemPasswordChar Then
            BtShowHidePass.Text = "hide"
            TBPassPhrase.UseSystemPasswordChar = False
        Else
            BtShowHidePass.Text = "show"
            TBPassPhrase.UseSystemPasswordChar = True
        End If

    End Sub

    Private Sub BtShowHideSign_Click(sender As Object, e As EventArgs) Handles BtShowHideSign.Click

        If TBSigKey.UseSystemPasswordChar Then
            BtShowHideSign.Text = "hide"
            TBSigKey.UseSystemPasswordChar = False
        Else
            BtShowHideSign.Text = "show"
            TBSigKey.UseSystemPasswordChar = True
        End If

    End Sub
    Private Sub BtShowHideSign2_Click(sender As Object, e As EventArgs) Handles BtShowHideSign2.Click

        If TBSigKey2.UseSystemPasswordChar Then
            BtShowHideSign2.Text = "hide"
            TBSigKey2.UseSystemPasswordChar = False
        Else
            BtShowHideSign2.Text = "show"
            TBSigKey2.UseSystemPasswordChar = True
        End If

    End Sub

    Private Sub BtShowHideAgree_Click(sender As Object, e As EventArgs) Handles BtShowHideAgree.Click

        If TBAgreeKey.UseSystemPasswordChar Then
            BtShowHideAgree.Text = "hide"
            TBAgreeKey.UseSystemPasswordChar = False
        Else
            BtShowHideAgree.Text = "show"
            TBAgreeKey.UseSystemPasswordChar = True
        End If

    End Sub

    Private Sub RBtWords_CheckedChanged(sender As Object, e As EventArgs) Handles RBtWords.CheckedChanged, RBtChars.CheckedChanged

        If RBtWords.Checked Then
            NUDWordsChars.Value = 12
        Else
            NUDWordsChars.Value = 64
        End If

    End Sub


    Private Function CharCnt(ByVal Input As String, ByVal Search As String) As Integer

        Dim Cnter As Integer = 0
        For i As Integer = 0 To Input.Length - 1

            Dim Chr As String = Input.Substring(i, 1)

            If Chr = Search Then
                Cnter += 1
            End If
        Next

        Return Cnter

    End Function


End Class
