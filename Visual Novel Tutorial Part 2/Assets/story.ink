// variables
VAR relationship_strength = 80
VAR mental_health = 50

VAR know_about_food_issue = false

-> start

=== start ===
Me: Hey babe?
Alice: Yeah?
Me: Are you feeling okay?
Alice: Yeah... why?
Me: Well, that's what I wanted to ask. You know.. after yesterday?
Alice: Oh... 
Alice: Yeah I'm feeling better, I was just stressed and my stomach hurt.
Me: I needed an angle to approach her. #thought
*** Is something bothering you?
-> is_something_bothering_you
*** I'm worried about your eating
-> ask_about_food
*** You threw up yesterday... didn't you?
-> ask_about_throwing_up

=== is_something_bothering_you ===
Me: Is something bothering you?
Alice: Wha... what do you mean?
Me: I mean... 
Me: You've been kind of distant lately.
Me: It's like something is constantly on your mind.
Alice: ...
Me: I'm not wrong am I?
Alice: No um...
Alice: You're probably right.
Me: What is it?
Me: You know you can tell me.
Alice: No I know I just um...
Alice: I don't know, I've not been really feeling myself recently.
Alice: I don't know what to tell you.
Me: Is it something with work?
Alice: No... it's nothing, it's... 
Alice: I don't think there's any specific reason, you know?
Me: I feel like she's hiding something. #thought
Me: But it seems like she's not comfortable talking about it #thought
Me: Maybe I should just let it go? #thought
Me: Or maybe I need a different angle? #thought
***I'm here for you
-> Here_for_you_ignorant
***I'm worried about your eating
-> ask_about_food
***You threw up yesterday... didn't you?
-> ask_about_throwing_up

=== ask_about_food ===
Alice: Wha... what do you mean?
Me: I mean... 
Me: You've been barely eating recently.
Me: You don't finish your meals.
Me: Is there something on your mind?
Alice: No... it's nothing it's... 
Alice: I've just not been hungry you know?
Me: That's cool but it's not how you normally are.
Me: I'm just worried, you know?
Alice: No I know um... I just...
Alice: I guess it's because of stress or something.
Alice: I've had a lot on my mind.
Me: Stress? Did something happen at work?
Alice: No, nothing happened. It's just... 
Alice: I don't know, I just don't feel very hungry.
Me: There's definitely something going on #thought
Me: She's just not saying it #thought
Me: Should I ask about something more specific? #thought
Me: Or just let it go? #thought
*** Did you eat breakfast? -> ask_about_breakfast 
*** I'm here for you -> Here_for_you_ignorant

=== ask_about_throwing_up ===
Me: I just have to be straightforward, I guess. #thought
Me: You threw up last night, didn't you?
Me: What happened?
Alice: I just, I...
Alice: I didn't feel good. My stomach felt funny and I thought maybe I should just, you know.
Me: So you threw up to make yourself feel better?
Alice: I guess, yeah.
Me: Well, did it help?
Alice: A bit. I must have eaten something weird.
Me: But you barely ate last night.
Alice: Umm... 
Alice: Yeah because of that.
Alice: Maybe it was something I'd eaten earlier.
Me: Hmm... #thought
Me: I don't think this is her true reason. #thought
Me: But at least she's not denying it, I guess. #thought
*** Next time you feel bad, talk to me. -> throwing_up_support
*** Throwing up is not the answer. -> throwing_up_dismiss

=== throwing_up_support ===
~relationship_strength += 10
~mental_health += 5
~know_about_food_issue = true
Me: I know it was a lot for her to tell me that when she was trying to deny it so hard. #thought
Me: I'm worried it wasn't just a one-off, though. #thought
Me: Babe, I know it's hard for you, but I'm on your side here, you know?
Me: Next time you don't feel good, just talk to me first, okay?
Me: We'll figure it out. 
Alice: I just, I was embarassed...
Alice: I didn't know what you'd think.
Me: Baby, you don't have to worry about stuff like that with me. 
Me: You know I'd never judge you.
Alice: I know... 
Alice: Thank you.
Me: Come here.
-> END

=== throwing_up_dismiss ===
~relationship_strength -= 5
~mental_health -= 10
Me: I don't really get why you'd force yourself to throw up.
Me: There are so many medications for bad stomach, why be so drastic?
Alice: I know...
Alice: I didn't really think about it you know.
Me: What!?
Me: You didn't think that it's not normal to force yourself to throw up!?
Alice: Well, no! 
Alice: Why all the questions, anyway?! 
Alice: I told you I didn't feel good!
Me: ...
Me: Just don't do it anymore, okay? 
Me: It's not like it's going to help with anything.
Alice: Yeah, I'm sorry...
-> END

=== Here_for_you_ignorant ===
~relationship_strength += 5
Me: I'm here for you babe, you know that?
Me: Anytime you want to talk, I'm here.
Me: Come here.
Me: I guess a cuddle and some support is all I can do for now. #thought
Me: She seems overwhelmed with whatever it is that's on her mind. #thought
-> END

=== ask_about_breakfast ===
Me: Did you eat breakfast today?
Alice: Of course!
Me: Wow that was quick. #thought
Alice: I mean... Yeah I did.
Alice: I had some cereal in the morning.
Alice: Why?
*** You don't have to hide things from me -> food_talk_gentle
*** Why are you lying? -> food_talk_pressure
*** No reason... -> food_talk_let_go

=== food_talk_gentle === 
Me: I know she's stressed out already, but I need to know the truth. #thought
Me: You don't have to hide things from me, you know that?
Me: I'm on your side.
Alice: I, I know.
Alice: It's just that...
Me: Hmm?
Alice: I just have been...
Alice: I keep thinking...
Alice: I keep thinking about putting on weight and I get worried and stressed out.
Me: ...
Alice: I guess that's why I haven't been eating properly... 
Me: Baby... 
Me: Come here.
Me: You know there is nothing to worry about, you're beautiful!
Alice: ...
Alice: Th- Thank you.
Me: I'm glad you told me.
Me: Now at least I understand what's going through your head.
Me: So thank you, I know it wasn't easy on you.
Alice: I'm sorry...
Me: You have nothing to be sorry about, don't apologise.
Alice: *Sob* I'm really worried though!
Me: I know baby.
Me: We'll deal with it, okay? Just remember I'm here for you.
Alice: Okay.
~mental_health +=5
~relationship_strength +=10
~know_about_food_issue = true
-> END

=== food_talk_pressure ===
Me: I can't believe she's lying to me about something this simple #thought
Me: I'm starting to be fed up with this evasiveness #thought
Me: Why are you lying to me?
-> too_many_questions

=== food_talk_let_go ===
Me: I can tell she's lying. #thought
Me: It seems like she really doesn't want to talk about it. #thought
Me: I probably shouldn't pressure her further on this. #thought
-> END

=== too_many_questions ===
Alice: What's up with all the questions!?
Alice: Why are you interrogating me like this? Like I've done something wrong?
Me: Wha- no, I just...
Alice: Just give me a break!
Me: ... #thought
Me: Wow. Well done me. #thought
~relationship_strength -= 10
~mental_health -=10
-> END
