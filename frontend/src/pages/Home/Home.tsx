export default function Home() {
    return (
        <div className="min-h-screen bg-gradient-to-br from-blue-50 to-indigo-100">
            <nav className="bg-white shadow">
                <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-4">
                    <h1 className="text-2xl font-bold text-indigo-600">Student Analytics System</h1>
                </div>
            </nav>

            <main className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-16">
                <div className="text-center">
                    <h2 className="text-4xl font-bold text-gray-900 mb-4">Welcome</h2>
                    <p className="text-xl text-gray-600 mb-8">
                        Comprehensive student performance analytics and insights for schools
                    </p>
                    
                    <div className="grid grid-cols-1 md:grid-cols-3 gap-6 mt-12">
                        <div className="bg-white p-6 rounded-lg shadow hover:shadow-lg transition">
                            <div className="text-3xl mb-2">📊</div>
                            <h3 className="text-lg font-semibold text-gray-900">Analytics</h3>
                            <p className="text-gray-600 mt-2">View detailed student performance data</p>
                        </div>

                        <div className="bg-white p-6 rounded-lg shadow hover:shadow-lg transition">
                            <div className="text-3xl mb-2">👥</div>
                            <h3 className="text-lg font-semibold text-gray-900">Students</h3>
                            <p className="text-gray-600 mt-2">Manage student information and records</p>
                        </div>

                        <div className="bg-white p-6 rounded-lg shadow hover:shadow-lg transition">
                            <div className="text-3xl mb-2">📈</div>
                            <h3 className="text-lg font-semibold text-gray-900">Reports</h3>
                            <p className="text-gray-600 mt-2">Generate comprehensive reports</p>
                        </div>
                    </div>
                </div>
            </main>
        </div>
    );
}