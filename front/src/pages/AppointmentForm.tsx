import { useState } from 'react';
import DatePickerOne from '../components/Forms/DatePicker/DatePickerOne';
import SelectGroupOne from '../components/Forms/SelectGroup/SelectGroupOne';
import agent from '../data/agent';
import { useAppSelector } from '../store/configureStore';
import Breadcrumb from '../components/Breadcrumbs/Breadcrumb';
import { useNavigate } from 'react-router-dom';

type Category =
  | 'Izdavanje dokumenata'
  | 'Plaćanje javnih usluga'
  | 'Zahtjevi za dozvole';

const AppointmentForm = () => {
  const [email, setEmail] = useState<string>('');
  const [selectedCategory, setSelectedCategory] = useState<Category | ''>('');
  const [selectedSubcategory, setSelectedSubcategory] = useState<string>('');
  const [selectedDate, setSelectedDate] = useState<Date | null>(null);
  const [selectedTime, setSelectedTime] = useState<string>('');
  const navigate = useNavigate();

  const token = useAppSelector((state) => state.auth.user?.token);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    // Prikupite podatke iz forme
    const formData = {
      UserEmail: email,
      ServiceType: selectedCategory,
      ServiceSubType: selectedSubcategory,
      AppointmentDate: selectedDate,
      AppointmentTime: selectedTime,
    };

    try {
      const response = await agent.Appointments.add(formData, token);
      console.log(response);
      alert('Uspješno ste zakazali termin.');
      navigate('/my-appointments');
    } catch (error) {
      console.error('Error adding appointment:', error);
    }
  };

  if (!token)
    return (
      <div className="text-center">
        <Breadcrumb pageName="Samo prijavljeni korisnici mogu pristupiti ovoj stranici" />
      </div>
    );

  return (
    <>
      <form onSubmit={handleSubmit}>
        <div className="grid grid-cols-1 gap-9 sm:grid-cols-2">
          <div className="flex flex-col gap-9 ">
            <div className="rounded-sm border border-stroke bg-white shadow-default dark:border-strokedark dark:bg-boxdark">
              <div className="border-b border-stroke py-4 px-6.5 dark:border-strokedark">
                <h2 className="font-medium text-black dark:text-white">
                  Popunite formu
                </h2>
              </div>
              <div className="p-6.5">
                <div className="mb-4.5">
                  <label className="mb-2.5 block text-black dark:text-white">
                    Email <span className="text-meta-1">*</span>
                  </label>
                  <input
                    type="email"
                    placeholder="Unesite email adresu"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    className="w-full rounded border-[1.5px] border-stroke bg-transparent py-3 px-5 text-black outline-none transition focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:text-white dark:focus:border-primary"
                  />
                </div>

                {/* SelectGroupOne Component */}
                <SelectGroupOne
                  selectedCategory={selectedCategory}
                  selectedSubcategory={selectedSubcategory}
                  onCategoryChange={setSelectedCategory}
                  onSubcategoryChange={setSelectedSubcategory}
                />

                {/* DatePickerOne Component */}
                <div className="flex flex-col gap-5.5 p-6.5">
                  <DatePickerOne onDateChange={setSelectedDate} />
                </div>

                {/* Time Input */}
                <div className="flex flex-col gap-5.5 p-6.5">
                  <div className="relative">
                    <div className="absolute inset-y-0 end-0 top-0 flex items-center pe-3.5 pointer-events-none">
                      <svg
                        className="w-4 h-4 text-gray-500 dark:text-gray-400"
                        aria-hidden="true"
                        xmlns="http://www.w3.org/2000/svg"
                        fill="currentColor"
                        viewBox="0 0 24 24"
                      >
                        <path
                          fillRule="evenodd"
                          d="M2 12C2 6.477 6.477 2 12 2s10 4.477 10 10-4.477 10-10 10S2 17.523 2 12Zm11-4a1 1 0 1 0-2 0v4a1 1 0 0 0 .293.707l3 3a1 1 0 0 0 1.414-1.414L13 11.586V8Z"
                          clipRule="evenodd"
                        />
                      </svg>
                    </div>
                    <input
                      type="time"
                      id="time"
                      className="bg-gray-50 border leading-none border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                      min="08:00"
                      max="16:00"
                      value={selectedTime}
                      onChange={(e) => setSelectedTime(e.target.value)}
                      required
                    />
                  </div>
                </div>

                <button className="flex w-full justify-center rounded bg-primary p-3 font-medium text-gray hover:bg-opacity-90">
                  Zakažite termin
                </button>
              </div>
            </div>
          </div>
        </div>
      </form>
      );
    </>
  );
};

export default AppointmentForm;
