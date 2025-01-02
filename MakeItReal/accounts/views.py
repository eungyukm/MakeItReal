from django.shortcuts import render
from django.contrib.auth import authenticate, login
from .models import User

# Create your views here.
def login(request):
    return render(request, 'accounts/login.html')

def login_result(request):
    if request.method == 'POST':
        input_email = request.POST['email']
        intput_password = request.POST['password']
        print(input_email)
        print(intput_password)
        user = User.objects.filter(email=input_email).first()
        
        if user is not None:
            if user.password == intput_password:
                return render(request, 'accounts/login.html')
            else:
                print('패스워드가 다릅니다.')
        else:
            print('로그인이 실패했습니다.')
            return render(request, 'accounts/login.html')
        
    return render(request, 'accounts/login.html')

def register(request):
    return render(request, 'accounts/register.html')

def register_result(request):
    if request.method == 'POST':
        input_username = request.POST['username']
        input_eamil = request.POST['email']
        input_password = request.POST['password1']
        input_password_confirm = request.POST['password2']

        print(input_username)
        print(input_eamil)
        print(input_password)
        print(input_password_confirm)
        user = User.objects.create(
            username=input_username,
            email=input_eamil,
            password=input_password,
            is_active=True
        )
        if user == None:
            print("user is None")
        user.save()

    return render(request, 'accounts/register.html')

