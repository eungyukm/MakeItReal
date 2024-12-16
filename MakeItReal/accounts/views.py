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
        user = User.objects.filter(email=input_email)

        if user is not None:
            if user.model.password == intput_password:
                return render(request, 'accounts/login.html')
            else:
                print('패스워드가 다릅니다.')
        else:
            print('로그인이 실패했습니다.')
            return render(request, 'accounts/login.html')
        
    return render(request, 'accounts/login.html')